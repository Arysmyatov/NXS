namespace NXS.Services.Abstract.XlsFormulaUpdater
{
    public interface IXlsSrcDescription
    {
        string XlsSheetName { get; set; }
        string RegionColLetter { get; set; }
        string ProcessSetColLetter { get; set; }
        string CommodityColLetter { get; set; }
        string AttributeColLetter { get; set; }
        string UserConstraintColLetter { get; set; }
        string CommoditySetColLetter { get; set; }
        string[] YearColLetters { get; set; }
        string SumLetter { get; set; }
        int RowBg { get; set; }
        int RowEnd { get; set; }
    }
}