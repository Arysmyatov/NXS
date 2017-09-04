namespace NXS.Services.Abstract.XlsFormulaUpdater
{
    public abstract class XlsAttributeVariableDescriptionAbstract : IXlsAttributeVariableDescription
    {
        public string ColLetter { get; set; }

        public string SrcColLetter { get; set; }

        public string GetAttributeFormula(string srcSheetName, int rowBg, int rowEnd, int currentRow)
        {
            return $",{ srcSheetName }!{ SrcColLetter }{rowBg}:{ SrcColLetter }{rowEnd},'By region'!{ColLetter}{currentRow}";
        }
    }
}