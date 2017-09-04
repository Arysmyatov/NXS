using OfficeOpenXml;

namespace NXS.Services.Abstract.XlsFormulaUpdater
{
    public interface IXlsFormulaUpdaterService
    {
        IXlsVariableDescription[] VariableDescriptions { get; set; }
        void Update();
        void SetWorkbook(ExcelWorkbook workbook);
    }
}