using NXS.Services.Abstract.XlsFormulaUpdater;
using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.FormulaUpdater.XlsVariableDescriptions
{
    // SHOULD BE IMPLEMENTED LATER

    public class Co2EmissionBySectorVariableDescription : XlsVariableDescriptionAbstract
    {

        private XlsRange FirstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 201,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 205,
                Col = 11
            }
        };


        public Co2EmissionBySectorVariableDescription()
        {
            XlsRanges = new XlsRange[] { };

            XlsSrcDescription = new XlsSrcDescription
            {
                XlsSheetName = "C_A03a",
                RegionColLetter = "B",
                CommoditySetColLetter = "C",

                YearColLetters = new string[] {
                            "D",
                            "E",
                            "F",
                            "G",
                            "H",
                            "I",
                            "J",
                            "K",
                            "L"
                        },
                RowBg = 5,
                RowEnd = 988
            };
        }
    }
}