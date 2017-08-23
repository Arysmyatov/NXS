using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NXS.Core;
using NXS.Core.Models;
using NXS.Services.Abstract;
using OfficeOpenXml;

namespace NXS.Services.Abstract
{
    public abstract class AggregationDataHandlerAbstract : IDataXlsImport<SubVariableData>
    {
        protected ExcelWorksheet _currentWorkSheet;
        protected readonly ExcelWorkbook _workBook;
        protected List<string> Years { get; set; }

        protected int _currentSubVariableId;
        protected int _currentRegionId;
        protected int _currentProcessSetId;
        protected int _currentCommodityId;
        protected int _currentCommoditySetId;
        protected int _currentAttributeId;
        protected int _currentUserConstraintId;
        protected int _currentRegionAgrigationTypeId;
        protected AgrigationXlsDescription _agrigationXlsDescription;

        protected List<SubVariableData> _subVariableDataList { get; set; }

        protected readonly IExcelImportDataService _excelImportDataService;

        public AggregationDataHandlerAbstract(IExcelImportDataService excelImportDataService)
        {
            _excelImportDataService = excelImportDataService;
        }

        public abstract Task<IEnumerable<SubVariableData>> GetDataFromXlsAsync();

        public abstract Task InsertDataToDbAsync(IEnumerable<SubVariableData> subVariableData);


        #region private methods

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


        internal async Task<int> GetProcessSetIdAsync(int currentRow)
        {
            var processSetNameVal = _currentWorkSheet.Cells[currentRow, _agrigationXlsDescription.ProcessSetCol].Value;
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


        internal async Task<int> GetCommodityIdAsync(int currentRow)
        {
            var commodityNameVal = _currentWorkSheet.Cells[currentRow, _agrigationXlsDescription.CommodityCol].Value;
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


        internal async Task<int> GetCommoditySetIdAsync(int currentRow)
        {
            var commoditySetNameVal = _currentWorkSheet.Cells[currentRow, _agrigationXlsDescription.CommoditySetCol].Value;
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


        internal async Task<int> GetAttributeIdAsync(int currentRow)
        {
            var attributeNameVal = _currentWorkSheet.Cells[currentRow, _agrigationXlsDescription.AttributeCol].Value;
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


        internal async Task<int> GetUserConstraintIdAsync(int currentRow)
        {
            var userConstraintNameVal = _currentWorkSheet.Cells[currentRow, _agrigationXlsDescription.UserConstraintCol].Value;
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
                    Year = Years[yearIndex],
                    Value = 0
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

                _subVariableDataList.Add(variableData);
                yearIndex++;
            }
        }


        internal void GetYears()
        {
            Years = new List<string>();
            for (var col = _agrigationXlsDescription.YearColBg; col <= _agrigationXlsDescription.YearColEnd; col++)
            {
                Years.Add(_currentWorkSheet.Cells[_agrigationXlsDescription.RowBg - 1, col].Value.ToString());
            }
        }


        internal void SetCurrentWorkSheet()
        {
            _currentWorkSheet = _excelImportDataService.CurrentWorkBook.Worksheets[_agrigationXlsDescription.SheetName];
        }


        internal async Task SetCurrentAttributes(int row)
        {
            try
            {
                _currentSubVariableId = await GetSubVariableIdAsync(row);

                if (_agrigationXlsDescription.ProcessSetCol > 0)
                {
                    _currentProcessSetId = await GetProcessSetIdAsync(row);
                }
                if (_agrigationXlsDescription.CommodityCol > 0)
                {
                    _currentCommodityId = await GetCommodityIdAsync(row);
                }
                if (_agrigationXlsDescription.CommoditySetCol > 0)
                {
                    _currentCommoditySetId = await GetCommoditySetIdAsync(row);
                }
                if (_agrigationXlsDescription.AttributeCol > 0)
                {
                    _currentAttributeId = await GetAttributeIdAsync(row);
                }
                if (_agrigationXlsDescription.UserConstraintCol > 0)
                {
                    _currentUserConstraintId = await GetUserConstraintIdAsync(row);
                }
            }
            catch (Exception)
            {
                // ToDo: log exception

            }

        }

        #endregion private methods        
    }
}