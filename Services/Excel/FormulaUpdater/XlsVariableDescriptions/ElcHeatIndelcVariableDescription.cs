using System.Collections.Generic;
using NXS.Services.Abstract.XlsFormulaUpdater;
using NXS.Services.Excel.FormulaUpdater.XlsVariableAttributesDescriptions;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.FormulaUpdater.XlsVariableDescriptions
{
    public class ElcHeatIndelcVariableDescription : XlsVariableDescriptionAbstract
    {

        private XlsRange FirstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 823,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 837,
                Col = 11
            }
        };


        public ElcHeatIndelcVariableDescription()
        {
            XlsRanges = new XlsRange[] {
                FirstRange
            };

            XlsSrcDescription = new XlsSrcDescription
            {
                XlsSheetName = "C_A01b",
                RegionColLetter = "B",
                ProcessSetColLetter = "C",
                CommodityColLetter= "D",

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
                RowEnd = 981
            };

            XlsAttributeVariableDescriptions = new List<IXlsAttributeVariableDescription> {
                new ProcessSetAtribute{
                    ColLetter = "M",
                    SrcColLetter = "C"
                },
                new CommodityAttribute{
                    ColLetter = "N",
                    SrcColLetter = "D"
                }
            };            

        }        
    }
}