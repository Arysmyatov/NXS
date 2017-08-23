using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NXS.Core;
using NXS.Core.Models;
using NXS.Services.Abstract;
using OfficeOpenXml;

namespace NXS.Services.Excel
{
    public class VariableDataHandler : IDataXlsImport<VariableData>
    {
        private ExcelWorksheet _currentWorkSheet;
        private readonly ExcelWorkbook _workBook;
        private List<string> Years { get; set; }

        private int _currentRegionId;
        private int _currentProcessSetId;
        private int _currentCommodityId;
        private int _currentCommoditySetId;
        private int _currentAttributeId;
        private int _currentUserConstraintId;
        private VariableXlsDescription variableXlsDescription;

        private List<VariableData> _variableDataList { get; set; }

        private readonly IExcelImportDataService _excelImportDataService;

        public VariableDataHandler(IExcelImportDataService excelImportDataService)
        {
            _excelImportDataService = excelImportDataService;
        }

        public async Task<IEnumerable<VariableData>> GetDataFromXlsAsync()
        {
            variableXlsDescription = _excelImportDataService.CurrentVariableXlsDescription;
            _variableDataList = new List<VariableData>();
            SetCurrentWorkSheet();
            GetYears();

            var row = variableXlsDescription.RowBg;
            do
            {
                try
                {
                    if (variableXlsDescription.RegionCol > 0)
                    {
                        _currentRegionId = await GetRegionIdAsync(row);
                    }
                    if (variableXlsDescription.ProcessSetCol > 0)
                    {
                        _currentProcessSetId = await GetProcessSetIdAsync(row);
                    }
                    if (variableXlsDescription.CommodityCol > 0)
                    {
                        _currentCommodityId = await GetCommodityIdAsync(row);
                    }
                    if (variableXlsDescription.CommoditySetCol > 0)
                    {
                        _currentCommoditySetId = await GetCommoditySetIdAsync(row);
                    }
                    if (variableXlsDescription.AttributeCol > 0)
                    {
                        _currentAttributeId = await GetAttributeIdAsync(row);
                    }

                    if (variableXlsDescription.UserConstraintCol > 0)
                    {
                        _currentUserConstraintId = await GetUserConstraintIdAsync(row);
                    }

                    AddVariables(row);
                    row++;

                }
                catch (Exception)
                {
                    // ToDo: log exception
                    continue;
                }

            } while (_currentRegionId > 0);

            return _variableDataList;
        }

        public async Task InsertDataToDbAsync(IEnumerable<VariableData> variableData)
        {
            foreach (var variableDataItem in variableData)
            {
                _excelImportDataService.VariableDataRepository.Add(variableDataItem);
                await _excelImportDataService.UnitOfWork.CompleteAsync();
            }
        }

        #region private methods

        private async Task<int> GetRegionIdAsync(int currentRow)
        {
            var regionNameVal = _currentWorkSheet.Cells[currentRow, variableXlsDescription.RegionCol].Value;
            if (regionNameVal == null)
            {
                return 0;
            }
            var regionName = regionNameVal.ToString();
            var region = await _excelImportDataService.RegionRepository.GetRegionByName(regionName);
            if (region == null)
            {
                region = new Region { Name = regionName };
                _excelImportDataService.RegionRepository.Add(region);
                await _excelImportDataService.UnitOfWork.CompleteAsync();
            }
            return region.Id;
        }


        private async Task<int> GetProcessSetIdAsync(int currentRow)
        {
            var processSetNameVal = _currentWorkSheet.Cells[currentRow, variableXlsDescription.ProcessSetCol].Value;
            if (processSetNameVal == null)
            {
                return 0;
            }
            var processSetName = processSetNameVal.ToString();
            var processSet = await _excelImportDataService.ProcessSetRepository.GetProcessSetByName(processSetName);

            if (processSet == null)
            {
                processSet = new ProcessSet { Name = processSetName };
                _excelImportDataService.ProcessSetRepository.Add(processSet);
                await _excelImportDataService.UnitOfWork.CompleteAsync();
            }
            return processSet.Id;
        }


        private async Task<int> GetCommodityIdAsync(int currentRow)
        {
            var commodityNameVal = _currentWorkSheet.Cells[currentRow, variableXlsDescription.CommodityCol].Value;
            if (commodityNameVal == null)
            {
                return 0;
            }
            var commodityName = commodityNameVal.ToString();
            var commodity = await _excelImportDataService.CommodityRepository.GetCommodityByName(commodityName);
            if (commodity == null)
            {
                commodity = new Commodity { Name = commodityName };
                _excelImportDataService.CommodityRepository.Add(commodity);
                await _excelImportDataService.UnitOfWork.CompleteAsync();
            }
            return commodity.Id;
        }


        private async Task<int> GetCommoditySetIdAsync(int currentRow)
        {
            var commoditySetNameVal = _currentWorkSheet.Cells[currentRow, variableXlsDescription.CommoditySetCol].Value;
            if (commoditySetNameVal == null)
            {
                return 0;
            }
            var commoditySetName = commoditySetNameVal.ToString();
            var commoditySet = await _excelImportDataService.CommoditySetRepository.GetCommoditySetByName(commoditySetName);
            if (commoditySet == null)
            {
                commoditySet = new CommoditySet { Name = commoditySetName };
                _excelImportDataService.CommoditySetRepository.Add(commoditySet);
                await _excelImportDataService.UnitOfWork.CompleteAsync();
            }
            return commoditySet.Id;
        }


        private async Task<int> GetAttributeIdAsync(int currentRow)
        {
            var attributeNameVal = _currentWorkSheet.Cells[currentRow, variableXlsDescription.AttributeCol].Value;
            if (attributeNameVal == null)
            {
                return 0;
            }
            var attributeName = attributeNameVal.ToString();

            var attribute = await _excelImportDataService.AttributeRepository.GetAttributeByName(attributeName);
            if (attribute == null)
            {
                attribute = new Core.Models.Attribute { Name = attributeName };
                _excelImportDataService.AttributeRepository.Add(attribute);
                await _excelImportDataService.UnitOfWork.CompleteAsync();
            }
            return attribute.Id;
        }


        private async Task<int> GetUserConstraintIdAsync(int currentRow)
        {
            var userConstraintNameVal = _currentWorkSheet.Cells[currentRow, variableXlsDescription.UserConstraintCol].Value;
            if (userConstraintNameVal == null)
            {
                return 0;
            }
            var userConstraintName = userConstraintNameVal.ToString();
            var userConstraint = await _excelImportDataService.UserConstraintRepository.GetUserConstraintByName(userConstraintName);
            if (userConstraint == null)
            {
                userConstraint = new Core.Models.UserConstraint { Name = userConstraintName };
                _excelImportDataService.UserConstraintRepository.Add(userConstraint);
                await _excelImportDataService.UnitOfWork.CompleteAsync();
            }
            return userConstraint.Id;
        }


        private void AddVariables(int row)
        {
            if (_currentRegionId == 0)
            {
                return;
            }

            var yearIndex = 0;
            for (var col = variableXlsDescription.YearColBg; col <= variableXlsDescription.YearColEnd; col++)
            {
                decimal currVal = 0;
                yearIndex = col - variableXlsDescription.YearColBg;
                var valObj = _currentWorkSheet.Cells[row, col].Value;
                if (valObj == null) continue;

                Decimal.TryParse(valObj.ToString(), out currVal);
                var variableData = new VariableData
                {
                    VariableId = _excelImportDataService.CurrentVariableId,
                    RegionId = _currentRegionId,
                    ScenarioId = _excelImportDataService.CurrentSecenarioId,
                    KeyParameterId = _excelImportDataService.CurrentKeyParameterId,
                    KeyParameterLevelId = _excelImportDataService.CurrentKeyParameterLevelId,
                    Year = Years[yearIndex],
                    Value = currVal
                };

                if (_currentProcessSetId > 0)
                {
                    variableData.ProcessSetId = _currentProcessSetId;
                }
                if (_currentCommodityId > 0)
                {
                    variableData.CommodityId = _currentCommodityId;
                }
                if (_currentCommoditySetId > 0)
                {
                    variableData.CommoditySetId = _currentCommoditySetId;
                }
                if (_currentAttributeId > 0)
                {
                    variableData.AttributeId = _currentAttributeId;
                }
                if (_currentUserConstraintId > 0)
                {
                    variableData.UserConstraintId = _currentUserConstraintId;
                }

                _variableDataList.Add(variableData);
                yearIndex++;
            }
        }


        private void GetYears()
        {
            Years = new List<string>();
            for (var col = variableXlsDescription.YearColBg; col <= variableXlsDescription.YearColEnd; col++)
            {
                Years.Add(_currentWorkSheet.Cells[variableXlsDescription.RowBg - 1, col].Value.ToString());
            }
        }


        private void SetCurrentWorkSheet()
        {
            _currentWorkSheet = _excelImportDataService.CurrentWorkBook.Worksheets[variableXlsDescription.SheetName];
        }

        #endregion private methods

    }
}