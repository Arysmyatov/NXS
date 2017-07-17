using System;
using System.Collections.Generic;
using NXS.Core.Models;
using OfficeOpenXml;

namespace NXS.Services.Strategies
{
    public class RegionStrategy : ExportStategyAbstastract
    {
        private readonly ExcelService _excelService;
        private IEnumerable<Data> Data { get; set; }

        public RegionStrategy(ExcelService excelService)
        {
            _excelService = excelService;
        }

        public override IEnumerable<Data> GetDataFromXls()
        {
            Data = new List<Data>();
            var currentWorkSheet = _excelService.CurrentWorkSheet;

            foreach (var region in _excelService.Regions)
            {
                setCurrenRegion(region.Name);

                foreach (var variable in _excelService.Variables)
                {
                    var variableXls = variable.VariableXls;
                    var yeras = GetYears(variableXls.YearBgRow, variableXls.YearBgCol, variableXls.YearEndCol);


                    for (var row = variableXls.DataBgRow; row <= variableXls.DataEndRow; row++) {
                        var subVariableName = currentWorkSheet.Cells[row, variableXls.DataBgCol].Value;
                        var subVariable = _excelService.GetSubVariable(subVariableName);

                    }


                }

            }

            return Data;
        }


        private void setCurrenRegion(string name)
        {
            _excelService.SetCurrentRegionXls(name);
        }

        private IEnumerable<YearItem> GetYears(int bgRow, int bgCol, int endCol)
        {
            var yearItems = new List<YearItem>();

            for (int col = bgCol; col <= endCol; col++)
            {
                var val = _excelService.CurrentWorkSheet.Cells[bgRow, col].Value;
                if (val == null)
                {
                    break;
                }

                try
                {
                    var yearItem = new YearItem { Row = bgRow, Col = col, Value = val.ToString() };
                    yearItems.Add(yearItem);
                }
                catch
                {
                    // ToDo: log error

                }
            }

            return yearItems;
        }





    }
}