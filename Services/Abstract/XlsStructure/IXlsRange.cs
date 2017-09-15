namespace NXS.Services.Abstract.XlsStucture
{
    public interface IXlsRange
    {
        string Prefix { get; set; }
        IXlsCell CellBg { get; set; }
        IXlsCell CellEnd { get; set; }
    }
}