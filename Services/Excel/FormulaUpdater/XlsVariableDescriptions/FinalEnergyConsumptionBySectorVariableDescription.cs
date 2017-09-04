using System.Collections.Generic;
using NXS.Services.Abstract.XlsFormulaUpdater;
using NXS.Services.Excel.FormulaUpdater.XlsVariableAttributesDescriptions;

namespace NXS.Services.Excel.FormulaUpdater.XlsVariableDescriptions
{
    public class FinalEnergyConsumptionBySectorVariableDescription : XlsVariableDescriptionAbstract
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


        private XlsRange SecondRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 209,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 209,
                Col = 11
            }
        };


        public FinalEnergyConsumptionBySectorVariableDescription()
        {
            XlsRanges = new XlsRange[] { FirstRange,
                                         SecondRange };

            XlsSrcDescription = new XlsSrcDescription
            {
                XlsSheetName = "C_A02c",
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
                RowEnd = 1000
            };

            XlsAttributeVariableDescriptions = new List<IXlsAttributeVariableDescription> {
                new ProcessSetAtribute()
            };
            
        }

    }
}