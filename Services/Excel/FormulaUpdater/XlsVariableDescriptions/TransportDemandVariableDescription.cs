using NXS.Services.Abstract.XlsFormulaUpdater;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.FormulaUpdater.XlsVariableDescriptions
{

    // SHOULD BE IMPLEMENTED LATER
    public class TransportDemandVariableDescription : XlsVariableDescriptionAbstract
    {
        private XlsRange FirstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 514,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 521,
                Col = 11
            }
        };

        private XlsRange SecondRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 524,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 531,
                Col = 11
            }
        };

        private XlsRange ThirdRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 534,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 541,
                Col = 11
            }
        };

        public TransportDemandVariableDescription()
        {
            XlsRanges = new XlsRange[] { };
            XlsSrcDescription = new XlsSrcDescription
            {
                XlsSheetName = "C_A08a",
                RegionColLetter = "B",
                ProcessSetColLetter = "C",
                CommodityColLetter = "D",
                YearColLetters = new string[] {
                            "E",
                            "F",
                            "G",
                            "H",
                            "I",
                            "J",
                            "K",
                            "L",
                            "M"
                        },
                RowBg = 5,
                RowEnd = 997
            };
        }
    }
}