using System.Collections.Generic;
using System.Text;
using NXS.Services.Abstract.XlsFormulaUpdater;

namespace NXS.Services.Excel.FormulaUpdater
{
    public class XlsFormulaBuilder
    {
        public static IXlsSrcDescription XlsSrcDescription { get; set; }
        public static IXlsRange XlsRange { get; set; }
        public static string NegativeChangeLetter { get; set; }
        public static string CrrentSumLetter { get; set; }

        public static int CurrentRow { get; set; }
        public static IEnumerable<IXlsAttributeVariableDescription> XlsAttributeVariableDescriptions { get; set; }


        public static string BuildFormula()
        {
            var formulaResult = new StringBuilder();
            var baseFormula = GetBaseFormula();
            formulaResult.Append(baseFormula);
            formulaResult.Append(GetAttributesFormula());

            formulaResult.Append(")");

            if (!string.IsNullOrEmpty(NegativeChangeLetter))
            {
                formulaResult.Append(GetNegativeChangeFormula());
            }

            return formulaResult.ToString();
        }

        private static string GetBaseFormula()
        {
            return $"SUMIFS({ XlsSrcDescription.XlsSheetName}!{CrrentSumLetter}{XlsSrcDescription.RowBg}:{CrrentSumLetter}{XlsSrcDescription.RowEnd},{XlsSrcDescription.XlsSheetName}!{XlsSrcDescription.RegionColLetter}{XlsSrcDescription.RowBg}:{XlsSrcDescription.RegionColLetter}{XlsSrcDescription.RowEnd},'By region'!B1";
        }

        private static string GetAttributesFormula()
        {
            var attributeFormulsBuillder = new StringBuilder();

            foreach(var xlsAttributeVariableDescription in XlsAttributeVariableDescriptions) {
                attributeFormulsBuillder.Append(xlsAttributeVariableDescription.GetAttributeFormula(XlsSrcDescription.XlsSheetName, XlsSrcDescription.RowBg, XlsSrcDescription.RowEnd, CurrentRow));
            }

            return attributeFormulsBuillder.ToString();
        }

        private static string GetNegativeChangeFormula()
        {
            return $"*{NegativeChangeLetter}{CurrentRow}";
        }

    }
}