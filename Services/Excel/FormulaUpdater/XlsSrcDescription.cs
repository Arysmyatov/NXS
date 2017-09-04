using NXS.Services.Abstract.XlsFormulaUpdater;

namespace NXS.Services.Excel.FormulaUpdater
{
    public class XlsSrcDescription: IXlsSrcDescription
    {
        public string XlsSheetName { get; set; }
        public string RegionColLetter { get; set; }
        public string ProcessSetColLetter { get; set; }
        public string CommodityColLetter { get; set; }
        public string AttributeColLetter { get; set; }
        public string UserConstraintColLetter { get; set; }
        public string CommoditySetColLetter { get; set; }
        public string[] YearColLetters { get; set; }
        public string SumLetter { get; set; }
        public int RowBg { get; set; }
        public int RowEnd { get; set; }
    }
}