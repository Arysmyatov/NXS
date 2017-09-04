using System.Collections.Generic;
using NXS.Services.Abstract.XlsFormulaUpdater;
using NXS.Services.Excel.FormulaUpdater.XlsVariableAttributesDescriptions;

namespace NXS.Services.Excel.FormulaUpdater.XlsVariableDescriptions
{
    public class ElectricCapacityAdditionsVariableDescription : XlsVariableDescriptionAbstract
    {
        private XlsRange FirstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 77,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 86,
                Col = 11
            }
        };

        private XlsRange SecondRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 88,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 90,
                Col = 11
            }
        };


        private XlsRange ThirdRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 92,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 94,
                Col = 11
            }
        };


        public ElectricCapacityAdditionsVariableDescription()
        {
            XlsRanges = new XlsRange[] { FirstRange,
                                        SecondRange,
                                        ThirdRange };

            XlsSrcDescription = new XlsSrcDescription
            {
                XlsSheetName = "C_A01e",
                RegionColLetter = "B",
                ProcessSetColLetter = "C",
                AttributeColLetter = "D",
                UserConstraintColLetter = "E",
                YearColLetters = new string[] {
                    "F",
                    "G",
                    "H",
                    "I",
                    "J",
                    "K",
                    "L",
                    "M",
                    "N"
                },
                RowBg = 5,
                RowEnd = 1009
            };

            XlsAttributeVariableDescriptions = new List<IXlsAttributeVariableDescription> {
                new ProcessSetAtribute(),
                new AttributeAttribute {
                    ColLetter = "N",
                    SrcColLetter = "D"
                },
                new UserConstraintAttribute {
                    ColLetter = "O",
                    SrcColLetter = "E"
                }                
            };
        }
    }
}