using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NXS.Core;
using NXS.Core.Models;
using NXS.Services.Abstract.XlsImport;
using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.DataImport.VariableDescriptions.Gdp;
using OfficeOpenXml;


namespace NXS.Services.Excel.DataImport
{
    public class GdpDataImporter : IDataImporter
    {
        private readonly string _workSheetName;
        private readonly string _regionAggregationTypeName;
        private string RegionAggregationTypeName { get; set; }
        private string[] CurrentYears { get; set; }
        private ExcelWorkbook CurrentWorkBook { get; set; }
        private ExcelWorksheet CurrentWorkSheet { get; set; }
        private int CurrenVariableId { get; set; }
        private int CurrenRegionId { get; set; }
        private int SubVariableCol { get; set; }
        public IXlsImportVariableDataService XlsImportVariableDataService { get; set; }
        private readonly IRegionRepository _regionRepository;
        private readonly IVariableRepository _variableRepository;
        private readonly ISubVariableRepository _subVariableRepository;
        private readonly ISubVariableDataRepository _subVariableDataRepository;
        private readonly IRegionAgrigationTypeRepository _regionAgrigationTypeRepository;
        private readonly IMapper _automapper;
        private readonly IUnitOfWork _unitOfWork;
        private int CurrentSubVariableId { get; set; }
        public int CurrentRegionAggregationTypeId { get; set; }


        public GdpDataImporter(IRegionRepository regionRepository,
                                         IVariableRepository variableRepository,
                                         ISubVariableRepository subVariableRepository,
                                         ISubVariableDataRepository subVariableDataRepository,
                                         IRegionAgrigationTypeRepository regionAgrigationTypeRepository,
                                         IMapper mapper,
                                         IUnitOfWork unitOfWork)
        {
            _regionRepository = regionRepository;
            _variableRepository = variableRepository;
            _subVariableRepository = subVariableRepository;
            _subVariableDataRepository = subVariableDataRepository;
            _regionAgrigationTypeRepository = regionAgrigationTypeRepository;
            _automapper = mapper;
            _unitOfWork = unitOfWork;

            _workSheetName = "By region";
            _regionAggregationTypeName = "By Region";
        }


        public async Task ImportDataAsync()
        {
            await SetCurrentRegionAgrigationTypeId();
            SetCurrentWorkSheet(_workSheetName);

            await ImportDataByVariableDescriptionsAsync();
        }


        public async Task RemoveDataAsync()
        {
            var queryObj = new SubVariableDataQuery
            {
                ScenarioId = XlsImportVariableDataService.CurrentScenarioId,
                KeyParameterId = XlsImportVariableDataService.CurrentKeyParameterId,
                KeyParameterLevelId = XlsImportVariableDataService.CurrentKeyParameterLevelId
            };
            _subVariableDataRepository.RemoveGdp(queryObj);
            _subVariableDataRepository.RemovePopulation(queryObj);
            await _unitOfWork.CompleteAsync();
        }


        #region Private methods

        private async Task ImportDataByVariableDescriptionsAsync()
        {
            var xlsVariableDescriptions = GetVariableDescriptions();

            foreach (var xlsVariableDescription in xlsVariableDescriptions)
            {
                SetCurrentWorkSheet(xlsVariableDescription.SheetName);
                await SetCurrentVariableIdAsync(xlsVariableDescription.VariableDbDescription);
                SubVariableCol = xlsVariableDescription.SubVariable.Col;

                var subVariableData = await GetDataByVariableDescriptionAsync(xlsVariableDescription);
                await AddSubVariableDataInDbAsync(subVariableData);
                //await SaveSubVariableDataInDbAsync(subVariableData);
            }
        }


        private IVariableDescription[] GetVariableDescriptions()
        {
            return GdpVariableDescriptions.GetAllDescriptions();
        }


        private async Task SetCurrentVariableIdAsync(IVariableDbDescription variableDbDescription)
        {
            var variable = await _variableRepository.GetVariable(variableDbDescription.VariableName, variableDbDescription.VariableGroupName);
            CurrenVariableId = variable.Id;
        }


        private async Task SaveSubVariableDataInDbAsync(IEnumerable<SubVariableData> subVariableData)
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


        private async Task AddSubVariableDataInDbAsync(IEnumerable<SubVariableData> subVariableData)
        {
            foreach (var subVariableDataItem in subVariableData)
            {
                _subVariableDataRepository.Add(subVariableDataItem);
            }
            await _unitOfWork.CompleteAsync();
        }


        private async Task<IEnumerable<SubVariableData>> GetDataByVariableDescriptionAsync(IVariableDescription xlsVariableDescription)
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


        private async Task<IEnumerable<SubVariableData>> GetXlsValuesByRangeAsync(IXlsRange currentRange)
        {
            var subVariableDataByRange = new List<SubVariableData>();

            var curentRow = currentRange.CellBg.Row;
            var regionName = GetXlsValue(curentRow, SubVariableCol);

            while (!string.IsNullOrEmpty(regionName))
            {
                await SetCurrentSubVariableId(regionName);
                await SetCurrentRegionId(regionName);

                var yearIndex = 0;
                for (var curentCol = currentRange.CellBg.Col + 1; curentCol <= currentRange.CellEnd.Col; curentCol++)
                {
                    var currentValue = GetCurrentValue(curentRow, curentCol);
                    var subVariableData = new SubVariableData
                    {
                        RegionAgrigationTypeId = CurrentRegionAggregationTypeId,
                        VariableId = CurrenVariableId,
                        SubVariableId = CurrentSubVariableId,
                        RegionId = CurrenRegionId,
                        ScenarioId = XlsImportVariableDataService.CurrentScenarioId,
                        KeyParameterId = XlsImportVariableDataService.CurrentKeyParameterId,
                        KeyParameterLevelId = XlsImportVariableDataService.CurrentKeyParameterLevelId,
                        Year = CurrentYears[yearIndex],
                        Value = currentValue
                    };
                    subVariableDataByRange.Add(subVariableData);
                    yearIndex++;
                }
                
                curentRow++;
                regionName = GetXlsValue(curentRow, SubVariableCol);
            };

            return subVariableDataByRange;
        }


        private async Task SetCurrentRegionAgrigationTypeId()
        {
            var regionAggregationTypeEntity = await _regionAgrigationTypeRepository.GetTypeAsync(_regionAggregationTypeName);
            CurrentRegionAggregationTypeId = regionAggregationTypeEntity.Id;
        }


        private decimal GetCurrentValue(int row, int col)
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


        private string GetXlsValue(int row, int col)
        {
            var val = CurrentWorkSheet.Cells[row, col].Value;
            var result = string.Empty;
            if (val == null)
            {
                return result;
            }

            try
            {
                result = val.ToString();
            }
            catch
            {
                return string.Empty;
            }

            return result;
        }


        private async Task SetCurrentSubVariableId(string subVariableName)
        {
            var subVariable = await _subVariableRepository.GetSubVariable(subVariableName);

            if (subVariable == null)
            {
                subVariable = new SubVariable { Name = subVariableName };
                _subVariableRepository.Add(subVariable);
                await _unitOfWork.CompleteAsync();
            }
            CurrentSubVariableId = subVariable.Id;
        }


        private async Task SetCurrentRegionId(string regionName)
        {
            var region = await _regionRepository.GetRegionByName(regionName);

            // if (region == null)
            // {
            //     region = new Region { Name = regionName,
            //     ParentRegionId =  CurrenParentRegion.Id};
            //     _subVariableRepository.Add(subVariable);
            //     await _unitOfWork.CompleteAsync();
            // }

            CurrenRegionId = region.Id;
        }


        private void SetCurrentYears(IYearDescription year)
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


        private async Task SetCurrentRegionIdAsync(string regionName)
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
            CurrenRegionId = region.Id;
        }


        private void SetCurrentWorkSheet(string workSheetName)
        {
            CurrentWorkSheet = XlsImportVariableDataService.CurrentWorkBook.Worksheets[workSheetName];
        }

        #endregion Private methods

    }
}