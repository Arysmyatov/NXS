using System.Collections.Generic;
using NXS.Services.Abstract.XlsFormulaUpdater;
using NXS.Services.Excel.FormulaUpdater.XlsVariableAttributesDescriptions;

namespace NXS.Services.Excel.FormulaUpdater.XlsVariableDescriptions
{
    public class ElectricityConsumptionBySectorVariableDescription : XlsVariableDescriptionAbstract
    {
        private XlsRange FirstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 37,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 41,
                Col = 11
            }
        };

        private XlsRange SecondRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 43,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 46,
                Col = 11
            }
        };

        public ElectricityConsumptionBySectorVariableDescription()
        {
            XlsRanges = new XlsRange[] { FirstRange,
                                      SecondRange };


            XlsSrcDescription = new XlsSrcDescription
            {
                XlsSheetName = "C_A01c",
                RegionColLetter = "B",
                ProcessSetColLetter = "C",
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

            XlsAttributeVariableDescriptions = new List<IXlsAttributeVariableDescription> {
                new ProcessSetAtribute()
            };            
        }

    }


}