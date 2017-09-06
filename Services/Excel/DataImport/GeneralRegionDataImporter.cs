using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NXS.Core;
using NXS.Core.Models;
using NXS.Services.Abstract.XlsImport;
using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.DataImport.VariableDescriptions.General;
using OfficeOpenXml;

namespace NXS.Services.Excel.DataImport
{
    public class GeneralRegionDataImporter : IGeneralRegionDataImporter
    {
        private const string ByRegionWorkSheetName = "By region";
        private const string RegionAggregationTypeName = "By Region";
        private IEnumerable<string> Regions { get; set; }
        public string[] CurrentYears { get; set; }
        private ExcelWorkbook CurrentWorkBook { get; set; }
        private ExcelWorksheet CurrentWorkSheet { get; set; }
        private int CurrenRegionId { get; set; }
        private int CurrenVariableId { get; set; }
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


        public GeneralRegionDataImporter(IRegionRepository regionRepository,
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
        }


        public async Task ImportDataAsync()
        {
            await SetCurrentRegionAgrigationTypeId();
            var regions = getRegionsMexico();
            foreach (var regionName in regions)
            {
                await SetCurrentRegionIdAsync(regionName);
                SetCurrentWorkSheet(ByRegionWorkSheetName);
                SetRegionInXls(regionName);
                RecalculateXlsResults();

                await ImportDataByVariableDescriptionsAsync();
            }
        }


        #region Private methods

        private async Task ImportDataByVariableDescriptionsAsync()
        {
            var xlsVariableDescriptions = GeneralVariableDescriptions.GetAllDescriptions();
            foreach (var xlsVariableDescription in xlsVariableDescriptions)
            {
                SetCurrentWorkSheet(xlsVariableDescription.SheetName);
                await SetCurrentVariableIdAsync(xlsVariableDescription.VariableDbDescription);
                SubVariableCol = xlsVariableDescription.SubVariable.Col;

                var subVariableData = await GetDataByVariableDescriptionAsync(xlsVariableDescription);
                await SaveSubVariableDataInDbAsync(subVariableData);
            }
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

                if (existSubVariableData.TotalItems > 0) {
                    var subVariableDataItemFromDb = existSubVariableData.Items.FirstOrDefault();
                    subVariableDataItemFromDb.Value = subVariableDataItem.Value;
                    _subVariableDataRepository.Update(subVariableDataItemFromDb);
                } else {
                    _subVariableDataRepository.Add(subVariableDataItem);
                }
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
            for (var curentRow = currentRange.CellBg.Row; curentRow <= currentRange.CellEnd.Row; curentRow++)
            {
                await SetCurrentSubVariableId(curentRow, SubVariableCol);

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
            }
            return subVariableDataByRange;
        }


        private async Task SetCurrentRegionAgrigationTypeId() {
            var regionAggregationTypeEntity = await _regionAgrigationTypeRepository.GetTypeAsync(RegionAggregationTypeName);
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


        private async Task SetCurrentSubVariableId(int currentRow, int subVariableCol)
        {
            var subVariableVal = CurrentWorkSheet.Cells[currentRow, subVariableCol].Value;
            if (subVariableVal == null)
            {
                CurrentSubVariableId = 0;
            }
            var subVariableName = subVariableVal.ToString();
            var subVariable = await _subVariableRepository.GetSubVariable(subVariableName);

            if (subVariable == null)
            {
                subVariable = new SubVariable { Name = subVariableName };
                _subVariableRepository.Add(subVariable);
                await _unitOfWork.CompleteAsync();
            }
            CurrentSubVariableId = subVariable.Id;
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


        private void RecalculateXlsResults()
        {
            CurrentWorkSheet.Calculate();
        }

        private void SetRegionInXls(string regionName)
        {
            CurrentWorkSheet.Cells[1, 2].Value = regionName;
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


        private IEnumerable<string> getRegionsEur()
        {
            return new string[] {
                "BNL",
                "DEU",
                "EEN",
                "EES",
                "FRA",
                "IAM",
                "IBE",
                "SDF",
                "UKI",
                "SWZ",
                "NOI"
            };
        }


        private IEnumerable<string> getRegionsMexico()
        {
            return new string[] {
                "CTR",
                "NES",
                "NOE",
                "OCC",
                "SSE"
            };
        }

        #endregion Private methods

    }
}