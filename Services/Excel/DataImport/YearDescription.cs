using NXS.Services.Abstract.XlsImport;
using NXS.Services.Abstract.XlsStucture;

namespace NXS.Services.Excel.DataImport
{
    public class YearDescription : IYearDescription
    {
        public IXlsCell CellBg { get; set; }
        public IXlsCell CellEnd { get; set; }                 
        
    }
}