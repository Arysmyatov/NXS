namespace NXS.Services.Abstract.XlsFormulaUpdater
{
    public interface IXlsAttributeVariableDescription
    {
        string ColLetter { get; set; }

        string GetAttributeFormula(string srcSheetName, int rowBg, int rowEnd, int currentRow);
    }
}