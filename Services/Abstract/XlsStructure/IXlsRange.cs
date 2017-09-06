namespace NXS.Services.Abstract.XlsStucture
{
    public interface IXlsRange
    {
        IXlsCell CellBg { get; set; }
        IXlsCell CellEnd { get; set; }
    }
}