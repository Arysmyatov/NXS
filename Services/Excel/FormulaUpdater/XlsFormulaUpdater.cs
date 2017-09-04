using System.IO;
using OfficeOpenXml;
using NXS.Services.Abstract.XlsFormulaUpdater;

namespace NXS.Services.Excel.FormulaUpdater
{
    public class XlsFormulaUpdater
    {

            public IXlsVariableDescription[] VariableDescriptions { get; set; }
            private ExcelWorksheet _currentWorkSheet { get; set; }

            public void Update()
            {
                // Open file
                var filePath = "Test-Results_Tables_TRN_ETM.xlsx";
                var fileInfo = new FileInfo(filePath);

                // Open Xls file
                using (var package = new ExcelPackage(fileInfo))
                {
                    _currentWorkSheet = package.Workbook.Worksheets["By region"];

                    foreach (var variableDescription in VariableDescriptions)
                    {
                        UpdateFormulas(variableDescription);
                    }
                    var fileInfoNew = new FileInfo("Test-Results_Tables_TRN_ETM_new.xlsx");
                    package.SaveAs(fileInfoNew);
                }
            }


            private void UpdateFormulas(IXlsVariableDescription variableDescription)
            {
                foreach (var range in variableDescription.XlsRanges)
                {
                    // follow rows
                    for (var row = range.CellBg.Row; row <= range.CellEnd.Row; row++)
                    {
                        var yearIndex = 0;
                        // follow collumns    
                        for (var col = range.CellBg.Col; col <= range.CellEnd.Col; col++)                                        
                        {
                            var xlsSrcDescription = variableDescription.XlsSrcDescription;
                            XlsFormulaBuilder.XlsRange = range;
                            XlsFormulaBuilder.XlsSrcDescription = xlsSrcDescription;
                            XlsFormulaBuilder.CurrentRow = row;
                            XlsFormulaBuilder.CrrentSumLetter = xlsSrcDescription.YearColLetters[yearIndex];                            
                            XlsFormulaBuilder.NegativeChangeLetter = variableDescription.NegativeChangeLetter;
                            XlsFormulaBuilder.XlsAttributeVariableDescriptions = variableDescription.XlsAttributeVariableDescriptions;

                            var formula = XlsFormulaBuilder.BuildFormula();
                            _currentWorkSheet.Cells[row, col].Formula = formula;

                            yearIndex++;
                        }
                    }
                }
            }        
        
    }
}