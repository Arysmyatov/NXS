/* 
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NXS.Core.Models;
using OfficeOpenXml;

namespace NXS.Services
{

    internal class WorkSheetScope
    {
        public int RowCount { get; set; }
        public int ColCount { get; set; }
        public VariableScope VariableScope { get; set; }
        private string _sheetName { get; set; }
        public ExcelWorksheet Worksheet { get; set; }
        private readonly ExcelPackage _excelPackage;

        public WorkSheetScope(ExcelPackage excelPackage, string sheetName)
        {
            this._excelPackage = excelPackage;
            _sheetName = sheetName;
            FindSheet();
        }

        private void FindSheet()
        {
            Worksheet = _excelPackage.Workbook.Worksheets[_sheetName];
        }

        public void GetRowColCount()
        {
            if (Worksheet == null)
            {
                return;
            }
            this.RowCount = Worksheet.Dimension.Rows;
            this.ColCount = Worksheet.Dimension.Columns;
        }
    }


    internal class VariableScope
    {
        public int BaseRow { get; set; }
        public int BaseCol { get; set; }

        private readonly WorkSheetScope _workSheetScope;
        private readonly VariableXls _variableXls;
        private readonly int _regionId;
        private readonly int _scenarioId;
        private readonly int _keyParameterLevelId;
        private readonly YearScope _yearScope;
        private readonly IEnumerable<KeyParameter> _keyParameters;


        public VariableScope(WorkSheetScope workSheetScope, VariableXls variableXls, IEnumerable<KeyParameter> keyParameters, int regionId, int scenarioId, int keyParameterLevelId)
        {
            this._workSheetScope = workSheetScope;
            this._variableXls = variableXls;
            this._regionId = regionId;
            this._scenarioId = scenarioId;
            this._keyParameterLevelId = keyParameterLevelId;
            this._keyParameters = keyParameters;

            this._yearScope = new YearScope(workSheetScope, this, variableXls);
        }

        public void GetScope()
        {
            // search for the variable scope
            var isScopeFound = false;
            for (int row = 1; row <= _workSheetScope.RowCount; row++)
            {
                for (int col = 1; col <= _workSheetScope.ColCount; col++)
                {
                    var cellValue = _workSheetScope.Worksheet.Cells[row, col].Value;
                    if(cellValue == null) {
                        continue;
                    }
                    if (cellValue.ToString() == _variableXls.Code)
                    {
                        this.BaseRow = row;
                        this.BaseCol = col;
                        isScopeFound = true;
                        break;
                    }
                }
                if (isScopeFound)
                {
                    break;
                }
            }
        }


        public IEnumerable<Data> GetDataFromXls()
        {
            var data = new List<Data>();

            GetScope();
            _yearScope.GetYears();

            // get Data
            foreach (var keyParameter in this._keyParameters)
            {
                var baseDataRow = this.BaseRow + _variableXls.DifForDataY;
                var baseDataCol = this.BaseCol + _variableXls.DifForDataX;
                var baseDataValRow = baseDataRow;
                var isFound = false;

                for (int row = baseDataRow; row <= _workSheetScope.RowCount; row++)
                {
                    var val = _workSheetScope.Worksheet.Cells[row, baseDataCol].Value;
                    if (val == null)
                    {
                        break;
                    }
                    if (val.ToString().Equals(keyParameter.Name))
                    {
                        baseDataValRow = row;
                        isFound = true;
                        break;
                    }
                }

                // if not found move to another Key Parameter
                if (!isFound)
                {
                    continue;
                }

                // Get Values
                foreach (var year in _yearScope.YearItems)
                {
                    var val = _workSheetScope.Worksheet.Cells[baseDataValRow, year.Col].Value;
                    if (val == null)
                    {
                        break;
                    }
                    try
                    {
                        var dataItem = new Data
                        {
                            RegionId = this._regionId,
                            ScenarioId = this._scenarioId,
                            VariableId = this._variableXls.VariableId,
                            KeyParameterId = keyParameter.Id,
                            KeyParameterLevelId = this._keyParameterLevelId,
                            Year = year.Value,
                            Value = decimal.Parse(val.ToString())
                        };
                        data.Add(dataItem);
                    }
                    catch
                    {
                    }
                }
            }

            return data;
        }

        internal class YearScope
        {
            private int BaseRow { get; set; }
            private int BaseCol { get; set; }
            public List<YearItem> YearItems { get; set; }

            private readonly VariableXls _variableXls;
            private readonly VariableScope _variableScope;
            private readonly WorkSheetScope _workSheetScope;

            public YearScope(WorkSheetScope workSheetScope, VariableScope variableScope, VariableXls variableXls)
            {
                _workSheetScope = workSheetScope;
                _variableScope = variableScope;
                _variableXls = variableXls;
            }

            private void InitBaseRowCol()
            {
                this.BaseRow = _variableScope.BaseRow + _variableXls.DifForYerasY;
                this.BaseCol = _variableScope.BaseCol + _variableXls.DifForYerasX;
            }

            public void GetYears()
            {
                InitBaseRowCol();

                YearItems = new List<YearItem>();

                for (int col = BaseCol; col <= _workSheetScope.ColCount; col++)
                {
                    var val = _workSheetScope.Worksheet.Cells[BaseRow, col].Value;
                    if (val == null)
                    {
                        break;
                    }

                    var yearItem = new YearItem { Row = BaseRow, Col = col, Value = val.ToString() };
                    YearItems.Add(yearItem);
                }
            }
        }


        internal struct YearItem
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public string Value { get; set; }
        }

        public class ExcelService
        {
            public string WorkBookBasePath { get; set; }
            public IEnumerable<KeyParameter> KeyParameters { get; set; }
            public IEnumerable<KeyParameterLevel> KeyParameterLevels { get; set; }
            public IEnumerable<VariableXls> VariablesXls { get; set; }
            public string SheetName { get; set; }

            public IEnumerable<Data> GetDataFromXls(Region region, Scenario scenario, KeyParameterLevel keyParameterLevel)
            {
                var data = new List<Data>();

                var filePath = $"{this.WorkBookBasePath}_{region.Name}_{scenario.Name}_{keyParameterLevel.Name}.xlsx";
                var fileInfo = new FileInfo(filePath);

                using (var package = new ExcelPackage(fileInfo))
                {

                    foreach (var varXls in VariablesXls)
                    {
                        // Get Sheet Row and Col count
                        var workSheetScope = new WorkSheetScope(package, varXls.SheetName);
                        workSheetScope.GetRowColCount();

                        // Find Variable Scope
                        var varScope = new VariableScope(workSheetScope, varXls, KeyParameters, region.Id, scenario.Id, keyParameterLevel.Id);
                        var dataByVariable = varScope.GetDataFromXls();
                        data.AddRange(dataByVariable);
                    }
                }

                return data;
            }
        }
    }
}

*/