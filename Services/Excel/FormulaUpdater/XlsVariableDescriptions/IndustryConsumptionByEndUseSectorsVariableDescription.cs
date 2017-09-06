using System.Collections.Generic;
using NXS.Services.Abstract.XlsFormulaUpdater;
using NXS.Services.Excel.FormulaUpdater.XlsVariableAttributesDescriptions;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.FormulaUpdater.XlsVariableDescriptions
{
    public class IndustryConsumptionByEndUseSectorsVariableDescription : XlsVariableDescriptionAbstract
    {
        private XlsRange FirstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 717,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 723,
                Col = 11
            }
        };


        public IndustryConsumptionByEndUseSectorsVariableDescription()
        {
            XlsRanges = new XlsRange[] { FirstRange };

            XlsSrcDescription = new XlsSrcDescription
            {
                XlsSheetName = "C_A10a",
                RegionColLetter = "B",
                ProcessSetColLetter = "C",
                CommoditySetColLetter = "D",
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
                RowEnd = 1004
            };

            XlsAttributeVariableDescriptions = new List<IXlsAttributeVariableDescription> {
                new ProcessSetAtribute{
                    ColLetter = "M",
                    SrcColLetter = "C"
                }
            };

        }

    }
}