namespace NXS.Services.Abstract.XlsFormulaUpdater
{
    public interface IXlsRange
    {
        IXlsCell CellBg { get; set; }
        IXlsCell CellEnd { get; set; }
    }
}