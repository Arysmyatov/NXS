using System.Collections.Generic;
using NXS.Services.Abstract.XlsStucture;

namespace NXS.Services.Abstract.XlsFormulaUpdater
{
    public interface IXlsVariableDescription
    {
        // public static string FormulaFormat = "SUMIFS({xlsSrcSheetName}!{sumLetter}{srcRowBg}:{sumLetter}{srcRowEnd},{xlsSrcSheetName}!{regionLetter}{srcRowBg}:{regionLetter}{srcRowBg},'By region'!B1";
        // public static string FirmulaFormat1 = "SUMIFS(C_A01a!E5:E169,C_A01a!B5:B169,'By region'!B1,C_A01a!C5:C169,'By region'!M7)";
        IXlsRange[] XlsRanges { get; set; }
        IXlsSrcDescription XlsSrcDescription { get; set; }
        ICollection<IXlsAttributeVariableDescription> XlsAttributeVariableDescriptions { get; set; }
        string NegativeChangeLetter { get; }
    }
}