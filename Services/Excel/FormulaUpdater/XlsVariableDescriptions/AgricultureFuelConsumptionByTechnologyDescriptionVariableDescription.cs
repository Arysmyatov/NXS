using System.Collections.Generic;
using NXS.Services.Abstract.XlsFormulaUpdater;
using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.FormulaUpdater.XlsVariableAttributesDescriptions;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.FormulaUpdater.XlsVariableDescriptions
{
    public class AgricultureFuelConsumptionByTechnologyDescriptionVariableDescription : XlsVariableDescriptionAbstract
    {
        private XlsRange FirstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 792,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 799,
                Col = 11
            }
        };


        public AgricultureFuelConsumptionByTechnologyDescriptionVariableDescription()
        {
            XlsRanges = new XlsRange[] {
                FirstRange
            };

            XlsSrcDescription = new XlsSrcDescription
            {
                XlsSheetName = "C_A10b",
                RegionColLetter = "B",
                ProcessSetColLetter = "C",
                CommoditySetColLetter= "D",

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
                RowEnd = 1000
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