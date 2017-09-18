using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using NXS.Core;
using NXS.Core.Models;
using NXS.Services.Abstract.XlsImport;
using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.DataImport.VariableDescriptions.General;
using OfficeOpenXml;

namespace NXS.Services.Excel.DataImport
{
    public abstract class RegionDataImporterAbstarct : IDataImporter
    {
        protected string ByRegionWorkSheetName { get; set; }
        protected string RegionAggregationTypeName { get; set; }
        protected string[] CurrentYears { get; set; }
        protected ExcelWorkbook CurrentWorkBook { get; set; }
        protected ExcelWorksheet CurrentWorkSheet { get; set; }
        protected int? CurrentRegionId { get; set; }
        protected int CurrenVariableId { get; set; }
        protected int SubVariableCol { get; set; }
        public IXlsImportVariableDataService XlsImportVariableDataService { get; set; }
        protected readonly IRegionRepository _regionRepository;
        protected readonly IVariableRepository _variableRepository;
        protected readonly ISubVariableRepository _subVariableRepository;
        protected readonly ISubVariableDataRepository _subVariableDataRepository;
        protected readonly IRegionAgrigationTypeRepository _regionAgrigationTypeRepository;
        protected readonly IMapper _automapper;
        protected readonly IUnitOfWork _unitOfWork;
        protected int CurrentSubVariableId { get; set; }
        public int CurrentRegionAggregationTypeId { get; set; }
        private readonly ILogger _logger;


        public RegionDataImporterAbstarct(IRegionRepository regionRepository,
                                         IVariableRepository variableRepository,
                                         ISubVariableRepository subVariableRepository,
                                         ISubVariableDataRepository subVariableDataRepository,
                                         IRegionAgrigationTypeRepository regionAgrigationTypeRepository,
                                         IMapper mapper,
                                         IUnitOfWork unitOfWork,
                                         ILoggerFactory loggerFactory)
        {
            _regionRepository = regionRepository;
            _variableRepository = variableRepository;
            _subVariableRepository = subVariableRepository;
            _subVariableDataRepository = subVariableDataRepository;
            _regionAgrigationTypeRepository = regionAgrigationTypeRepository;
            _automapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = loggerFactory.CreateLogger("NXS.Services.Excel.DataImport.RegionDataImporterAbstarct");
        }


        public abstract Task ImportDataAsync();

        public abstract Task RemoveDataAsync();


        #region Private methods

        protected async Task ImportDataByVariableDescriptionsAsync()
        {
            var xlsVariableDescriptions = GetVariableDescriptions();

            foreach (var xlsVariableDescription in xlsVariableDescriptions)
            {
                _logger.LogInformation($"Started the import for { xlsVariableDescription.SheetName } - { xlsVariableDescription.GetType() }  ");                


                SetCurrentWorkSheet(xlsVariableDescription.SheetName);
                await SetCurrentVariableIdAsync(xlsVariableDescription.VariableDbDescription);
                SubVariableCol = xlsVariableDescription.SubVariable.Col;

                var subVariableData = await GetDataByVariableDescriptionAsync(xlsVariableDescription);
                await AddSubVariableDataInDbAsync(subVariableData);

                _logger.LogInformation($"Finish the import for { xlsVariableDescription.SheetName } - { xlsVariableDescription.GetType() }  ");                                
            }
        }


        protected abstract IVariableDescription[] GetVariableDescriptions();


        protected async Task SetCurrentVariableIdAsync(IVariableDbDescription variableDbDescription)
        {
            var variable = await _variableRepository.GetVariable(variableDbDescription.VariableName, variableDbDescription.VariableGroupName);
            CurrenVariableId = variable.Id;
        }


        protected async Task SaveSubVariableDataInDbAsync(IEnumerable<SubVariableData> subVariableData)
        {
            foreach (var subVariableDataItem in subVariableData)
            {
                var subVariableDataQuery = new SubVariableDataQuery();
                subVariableDataQuery.RegionId = subVariableDataItem.RegionId;
                subVariableDataQuery.ScenarioId = subVariableDataItem.ScenarioId;
                subVariableDataQuery.VariableId = subVariableDataItem.VariableId;
                subVariableDataQuery.SubVariableId = subVariableDataItem.SubVariableId;
                subVariableDataQuery.KeyParameterId = subVariableDataItem.KeyParameterId;
                subVariableDataQuery.KeyParameterLevelId = subVariableDataItem.KeyParameterLevelId;
                subVariableDataQuery.RegionAgrigationTypeId = subVariableDataItem.RegionAgrigationTypeId;
                subVariableDataQuery.Year = subVariableDataItem.Year;

                var existSubVariableData = await _subVariableDataRepository.GetSubVariableData(subVariableDataQuery);

                if (existSubVariableData.TotalItems > 0)
                {
                    var subVariableDataItemFromDb = existSubVariableData.Items.FirstOrDefault();
                    subVariableDataItemFromDb.Value = subVariableDataItem.Value;
                    _subVariableDataRepository.Update(subVariableDataItemFromDb);
                }
                else
                {
                    _subVariableDataRepository.Add(subVariableDataItem);
                }
            }
            await _unitOfWork.CompleteAsync();
        }


        protected async Task AddSubVariableDataInDbAsync(IEnumerable<SubVariableData> subVariableData)
        {
            foreach (var subVariableDataItem in subVariableData)
            {
                _subVariableDataRepository.Add(subVariableDataItem);
            }
            await _unitOfWork.CompleteAsync();
        }


        protected async Task<IEnumerable<SubVariableData>> GetDataByVariableDescriptionAsync(IVariableDescription xlsVariableDescription)
        {
            SetCurrentYears(xlsVariableDescription.Year);
            var data = new List<SubVariableData>();

            foreach (var currentRange in xlsVariableDescription.XlsRanges)
            {
                var dataByXlsRange = await GetXlsValuesByRangeAsync(currentRange);
                data.AddRange(dataByXlsRange);
            }

            return data;
        }


        protected async Task<IEnumerable<SubVariableData>> GetXlsValuesByRangeAsync(IXlsRange currentRange)
        {
            var subVariableDataByRange = new List<SubVariableData>();
            for (var curentRow = currentRange.CellBg.Row; curentRow <= currentRange.CellEnd.Row; curentRow++)
            {
                await SetCurrentSubVariableId(curentRow, SubVariableCol, currentRange.Prefix);

                var yearIndex = 0;
                for (var curentCol = currentRange.CellBg.Col + 1; curentCol <= currentRange.CellEnd.Col; curentCol++)
                {
                    var currentValue = GetCurrentValue(curentRow, curentCol);
                    var subVariableData = new SubVariableData
                    {
                        RegionAgrigationTypeId = CurrentRegionAggregationTypeId,
                        VariableId = CurrenVariableId,
                        SubVariableId = CurrentSubVariableId,
                        RegionId = CurrentRegionId,
                        ParentRegionId = XlsImportVariableDataService.CurrentParentRegionId,
                        ScenarioId = XlsImportVariableDataService.CurrentScenarioId,
                        KeyParameterId = XlsImportVariableDataService.CurrentKeyParameterId,
                        KeyParameterLevelId = XlsImportVariableDataService.CurrentKeyParameterLevelId,
                        Year = CurrentYears[yearIndex],
                        Value = currentValue
                    };
                    subVariableDataByRange.Add(subVariableData);
                    yearIndex++;
                }
            }
            return subVariableDataByRange;
        }


        protected async Task SetCurrentRegionAgrigationTypeId()
        {
            var regionAggregationTypeEntity = await _regionAgrigationTypeRepository.GetTypeAsync(RegionAggregationTypeName);
            CurrentRegionAggregationTypeId = regionAggregationTypeEntity.Id;
        }


        protected decimal GetCurrentValue(int row, int col)
        {
            decimal currVal = 0;
            var valObj = CurrentWorkSheet.Cells[row, col].Value;
            if (valObj == null) return 0;
            var valsStr = string.Empty;
            try
            {
                Decimal.TryParse(valObj.ToString(), out currVal);
            }
            catch
            {
                return 0;
            }
            return currVal;
        }


        protected async Task SetCurrentSubVariableId(int currentRow, int subVariableCol, string currentRangePref = "")
        {
            var subVariableVal = CurrentWorkSheet.Cells[currentRow, subVariableCol].Value;
            if (subVariableVal == null)
            {
                CurrentSubVariableId = 0;
            }
            var subVariableName = !string.IsNullOrEmpty(currentRangePref) ? $"{currentRangePref} - {subVariableVal.ToString()}" 
                                                                            : subVariableVal.ToString();

            var subVariable = await _subVariableRepository.GetSubVariable(subVariableName);

            if (subVariable == null)
            {
                subVariable = new SubVariable { Name = subVariableName };
                _subVariableRepository.Add(subVariable);
                await _unitOfWork.CompleteAsync();
            }
            CurrentSubVariableId = subVariable.Id;
        }


        protected void SetCurrentYears(IYearDescription year)
        {
            CurrentYears = new string[year.CellEnd.Col - year.CellBg.Col + 1];
            var currentYeraIndex = 0;
            for (int yearCol = year.CellBg.Col; yearCol <= year.CellEnd.Col; yearCol++)
            {
                var valObj = CurrentWorkSheet.Cells[year.CellBg.Row, yearCol].Value;
                if (valObj == null)
                {
                    continue;
                }
                CurrentYears[currentYeraIndex] = valObj.ToString();
                currentYeraIndex++;
            }
        }


        protected async Task SetCurrentRegionIdAsync(string regionName)
        {
            var region = await _regionRepository.GetRegionByName(regionName);
            if (region == null)
            {
                region = new Region
                {
                    Name = regionName,
                    ParentRegionId = XlsImportVariableDataService.CurrentParentRegionId
                };
                _regionRepository.Add(region);
                await _unitOfWork.CompleteAsync();
            }
            CurrentRegionId = region.Id;
        }


        protected void SetCurrentWorkSheet(string workSheetName)
        {
            CurrentWorkSheet = XlsImportVariableDataService.CurrentWorkBook.Worksheets[workSheetName];
        }

        #endregion Private methods

    }
}