using NXS.Services.Abstract.XlsStucture;

namespace NXS.Services.Abstract.XlsImport
{
    public interface IYearDescription
    {
        IXlsCell CellBg { get; set; }
        IXlsCell CellEnd { get; set; }                 
    }
}