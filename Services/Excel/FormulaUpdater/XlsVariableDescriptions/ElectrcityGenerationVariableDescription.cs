using System.Collections.Generic;
using NXS.Services.Abstract.XlsFormulaUpdater;
using NXS.Services.Excel.FormulaUpdater.XlsVariableAttributesDescriptions;
using NXS.Services.Excel.FormulaUpdater.XlsVariableDescriptions;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.FormulaUpdater.XlsVariableDescriptions
{
    public class ElectrcityGenerationVariableDescription : XlsVariableDescriptionAbstract
    {
        private XlsRange FirstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 7,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 16,
                Col = 11
            }
        };

        private XlsRange SecondRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 18,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 20,
                Col = 11
            }
        };

        private XlsRange ThirdRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 22,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 24,
                Col = 11
            }
        };


        public ElectrcityGenerationVariableDescription()
        {
            XlsRanges = new XlsRange[] { FirstRange,
                                         SecondRange,
                                         ThirdRange };

            XlsSrcDescription = new XlsSrcDescription
            {
                XlsSheetName = "C_A01a",
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