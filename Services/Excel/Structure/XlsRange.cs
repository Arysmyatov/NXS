using NXS.Services.Abstract.XlsStucture;

namespace NXS.Services.Excel.Structure
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