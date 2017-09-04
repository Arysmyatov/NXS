using NXS.Services.Abstract.XlsFormulaUpdater;

namespace NXS.Services.Excel.FormulaUpdater
{
    public class XlsCell: IXlsCell
    {
        public int Col { get; set; }
        public int Row { get; set; }
    }
}