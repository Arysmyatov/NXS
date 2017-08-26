using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NXS.Core;
using NXS.Core.Models;
using NXS.Services.Abstract;
using NXS.Services.Excel;
using OfficeOpenXml;

namespace NXS.Services.Excel
{
    public class AggregationDataHandlerGdp : IDataXlsImport<SubVariableData> 
    {
        private ExcelWorksheet _currentWorkSheet;   
        private int _currentSubVariableId;             
        private int _currentRegionId;             
        private readonly IExcelImportDataService _excelImportDataService;
        private AgrigationXlsDescription _agrigationXlsDescription;      
        protected int _currentRegionAgrigationTypeId;                  
        private List<SubVariableData> _subVariableDataList;
        private List<string> Years { get; set; }


        public AggregationDataHandlerGdp(IExcelImportDataService excelImportDataService){

            _excelImportDataService = excelImportDataService;
        }


        public async Task<IEnumerable<SubVariableData>> GetDataFromXlsAsync()
        {
            _agrigationXlsDescription = _excelImportDataService.CurrentAgrigationXlsDescription;
            _currentRegionAgrigationTypeId = _excelImportDataService.CurrentAgrigationXlsDescription.RegionAgrigationTypeId;
            _subVariableDataList = new List<SubVariableData>();
            SetCurrentWorkSheet();
            GetYears();

            for (var row = _agrigationXlsDescription.RowBg; row <= _agrigationXlsDescription.RowEnd; row++)
            {
                try
                {
                    await SetCurrentAttributes(row);
                    AddSubVariables(row);
                }
                catch (Exception)
                {
                    // ToDo: log exception
                    continue;
                }
            }

            return _subVariableDataList;            

        }


        public async Task InsertDataToDbAsync(IEnumerable<SubVariableData> subVariableData)
        {
            foreach (var subVariableDataItem in subVariableData)
            {
                _excelImportDataService.SubVariableDataRepository.Add(subVariableDataItem);
                await _excelImportDataService.UnitOfWork.CompleteAsync();
            }
        }


        #region private Methods

        private void SetCurrentWorkSheet()
        {
            _currentWorkSheet = _excelImportDataService.CurrentWorkBook.Worksheets[_agrigationXlsDescription.SheetName];
        }

        private void GetYears()
        {
            Years = new List<string>();
            for (var col = _agrigationXlsDescription.YearColBg; col <= _agrigationXlsDescription.YearColEnd; col++)
            {
                Years.Add(_currentWorkSheet.Cells[_agrigationXlsDescription.RowBg - 1, col].Value.ToString());
            }
        }        



        internal async Task SetCurrentAttributes(int row)
        {
            try
            {
                _currentSubVariableId = await GetSubVariableIdAsync(row);
                _currentRegionId = await GetRegionIdAsync(row);                
            }
            catch (Exception)
            {
                // ToDo: log exception

            }

        }        


        internal async Task<int> GetSubVariableIdAsync(int currentRow)
        {
            var subVariableVal = _currentWorkSheet.Cells[currentRow, _agrigationXlsDescription.SubVariableCol].Value;
            if (subVariableVal == null)
            {
                return 0;
            }
            var subVariableName = subVariableVal.ToString();
            var subVariable = await _excelImportDataService.SubVariableRepository.GetSubVariable(subVariableName);

            if (subVariable == null)
            {
                subVariable = new SubVariable { Name = subVariableName };
                _excelImportDataService.SubVariableRepository.Add(subVariable);
                await _excelImportDataService.UnitOfWork.CompleteAsync();
            }
            return subVariable.Id;
        }
        

        internal async Task<int> GetRegionIdAsync(int currentRow)
        {
            var regionVal = _currentWorkSheet.Cells[currentRow, _agrigationXlsDescription.SubVariableCol].Value;
            if (regionVal == null)
            {
                return 0;
            }
            var regionName = regionVal.ToString();
            var region = await _excelImportDataService.RegionRepository.GetRegionByName(regionName);

            if (region == null)
            {
                region = new Region { Name = regionName };
                _excelImportDataService.RegionRepository.Add(region);
                await _excelImportDataService.UnitOfWork.CompleteAsync();
            }
            return region.Id;
        }
        

        internal void AddSubVariables(int row)
        {
            if (_currentSubVariableId == 0)
            {
                return;
            }

            var yearIndex = 0;
            for (var col = _agrigationXlsDescription.YearColBg; col <= _agrigationXlsDescription.YearColEnd; col++)
            {
                var variableData = new SubVariableData
                {
                    VariableId = _excelImportDataService.CurrentVariableId,
                    SubVariableId = _currentSubVariableId,
                    RegionAgrigationTypeId = _currentRegionAgrigationTypeId,
                    RegionId = _currentRegionId,
                    ScenarioId = _excelImportDataService.CurrentSecenarioId,
                    KeyParameterId = _excelImportDataService.CurrentKeyParameterId,
                    KeyParameterLevelId = _excelImportDataService.CurrentKeyParameterLevelId,
                    Year = Years[yearIndex]
                };

                decimal currVal = 0;
                var valObj = _currentWorkSheet.Cells[row, col].Value;
                if (valObj != null) {
                    Decimal.TryParse(valObj.ToString(), out currVal);
                    variableData.Value = currVal;
                }

                _subVariableDataList.Add(variableData);
                yearIndex++;
            }
        }

        #endregion private Methods
    }
}