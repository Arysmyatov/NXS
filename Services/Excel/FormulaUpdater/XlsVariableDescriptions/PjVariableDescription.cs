using System.Collections.Generic;
using NXS.Services.Abstract.XlsFormulaUpdater;
using NXS.Services.Excel.FormulaUpdater.XlsVariableAttributesDescriptions;

namespace NXS.Services.Excel.FormulaUpdater.XlsVariableDescriptions
{
    public class PjVariableDescription : XlsVariableDescriptionAbstract
    {
        private XlsRange FirstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 168,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 177,
                Col = 11
            }
        };


        public PjVariableDescription()
        {
            XlsRanges = new XlsRange[] { FirstRange };

            XlsSrcDescription = new XlsSrcDescription
            {
                XlsSheetName = "C_A02a",
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