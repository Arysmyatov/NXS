using System.Collections.Generic;
using NXS.Services.Abstract.XlsFormulaUpdater;
using NXS.Services.Excel.FormulaUpdater.XlsVariableAttributesDescriptions;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.FormulaUpdater.XlsVariableDescriptions
{
    public class PrimaryEnergySupplyVariableDescription : XlsVariableDescriptionAbstract
    {

        private XlsRange FirstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 125,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 145,
                Col = 11
            }
        };


        public PrimaryEnergySupplyVariableDescription()
        {
            NegativeChangeLetter = "L";
            XlsRanges = new XlsRange[] { FirstRange };
            XlsSrcDescription = new XlsSrcDescription
            {
                XlsSheetName = "C_A02x",
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