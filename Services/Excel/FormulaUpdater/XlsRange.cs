using NXS.Services.Abstract.XlsFormulaUpdater;

namespace NXS.Services.Excel.FormulaUpdater
{
    public class XlsRange: IXlsRange
    {
        public IXlsCell CellBg { get; set; }
        public IXlsCell CellEnd { get; set; }

        public XlsRange()
        {
            CellBg = new XlsCell();
            CellEnd = new XlsCell();
        }
    }
}