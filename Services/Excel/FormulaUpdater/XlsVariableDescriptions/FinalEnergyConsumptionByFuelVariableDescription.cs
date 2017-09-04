using System.Collections.Generic;
using NXS.Services.Abstract.XlsFormulaUpdater;
using NXS.Services.Excel.FormulaUpdater.XlsVariableAttributesDescriptions;

namespace NXS.Services.Excel.FormulaUpdater.XlsVariableDescriptions
{
    public class FinalEnergyConsumptionByFuelVariableDescription : XlsVariableDescriptionAbstract
    {
        private XlsRange FirstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 184,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 190,
                Col = 11
            }
        };

        private XlsRange SecondRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 192,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 194,
                Col = 11
            }
        };


        public FinalEnergyConsumptionByFuelVariableDescription()
        {
            XlsRanges = new XlsRange[] { FirstRange,
                                         SecondRange };

            XlsSrcDescription = new XlsSrcDescription
            {
                XlsSheetName = "C_A02b",
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