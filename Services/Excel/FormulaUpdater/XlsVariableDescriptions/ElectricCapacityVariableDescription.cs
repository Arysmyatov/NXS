using System.Collections.Generic;
using NXS.Services.Abstract.XlsFormulaUpdater;
using NXS.Services.Excel.FormulaUpdater.XlsVariableAttributesDescriptions;

namespace NXS.Services.Excel.FormulaUpdater.XlsVariableDescriptions
{
    public class ElectricCapacityVariableDescription : XlsVariableDescriptionAbstract
    {
        private XlsRange FirstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 54,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 62,
                Col = 11
            }
        };


        private XlsRange SecondRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 64,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 66,
                Col = 11
            }
        };


        private XlsRange ThirdRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 68,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 70,
                Col = 11
            }
        };


        public ElectricCapacityVariableDescription()
        {
            XlsRanges = new XlsRange[] { FirstRange,
                                    SecondRange,
                                    ThirdRange };

            XlsSrcDescription = new XlsSrcDescription
            {
                XlsSheetName = "C_A01d",
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
                RowEnd = 1004
            };

            XlsAttributeVariableDescriptions = new List<IXlsAttributeVariableDescription> {
                new ProcessSetAtribute()
            };                        
        }
    }
}