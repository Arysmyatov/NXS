using Microsoft.Extensions.Logging;
using NXS.Services.Abstract.XlsFormulaUpdater;
using OfficeOpenXml;

namespace NXS.Services.Excel.FormulaUpdater
{
    public class XlsFormulaUpdaterService : IXlsFormulaUpdaterService
    {
        public IXlsVariableDescription[] VariableDescriptions { get; set; }

        private ExcelWorksheet _currentWorkSheet { get; set; }
        private ExcelWorkbook _currentWorkBook { get; set; }

        private readonly ILogger _logger;

        public XlsFormulaUpdaterService(ILoggerFactory loggerFactory){

            _logger = loggerFactory.CreateLogger("NXS.Services.Excel.FormulaUpdater.XlsFormulaUpdaterService");
        }

        public void Update()
        {
            _currentWorkSheet = _currentWorkBook.Worksheets["By region"];

            foreach (var variableDescription in VariableDescriptions)
            {
                UpdateFormulas(variableDescription);
            }
        }


        public void SetWorkbook(ExcelWorkbook workbook)
        {
            _currentWorkBook = workbook;
        }


        private void UpdateFormulas(IXlsVariableDescription variableDescription)
        {

            _logger.LogInformation($"Started Update formulas for { variableDescription.XlsSrcDescription.XlsSheetName } - { variableDescription.GetType() }  ");

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

            _logger.LogInformation($"Finish Update formulas for { variableDescription.XlsSrcDescription.XlsSheetName } - { variableDescription.GetType() }  ");
        }
    }
}