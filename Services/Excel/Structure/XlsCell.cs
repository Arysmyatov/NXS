using NXS.Services.Abstract.XlsStucture;

namespace NXS.Services.Excel.Structure
{
    public class XlsCell: IXlsCell
    {
        public int Row { get; set; }        
        public int Col { get; set; }
    }
}