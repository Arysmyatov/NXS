using System.Collections.Generic;
using NXS.Services.Abstract.XlsFormulaUpdater;
using NXS.Services.Excel.FormulaUpdater.XlsVariableAttributesDescriptions;

namespace NXS.Services.Excel.FormulaUpdater.XlsVariableDescriptions
{
    public class IndustryConsumptionByEndUseSectors2VariableDescription : XlsVariableDescriptionAbstract
    {
        private XlsRange AgricultureRange = new XlsRange
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

        private XlsRange CommercialRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 801,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 808,
                Col = 11
            }
        };          

       private XlsRange ResidentialRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 710,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 717,
                Col = 11
            }
        };                    
        

        public IndustryConsumptionByEndUseSectors2VariableDescription() {
            XlsRanges = new XlsRange[] { AgricultureRange,  CommercialRange, ResidentialRange}; 

            XlsSrcDescription = new XlsSrcDescription
            {
                XlsSheetName = "C_A10b",
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
                RowEnd = 1000
            };   

            XlsAttributeVariableDescriptions = new List<IXlsAttributeVariableDescription> {
                new ProcessSetAtribute{
                    ColLetter = "M",
                    SrcColLetter = "C"
                },
                new CommoditySetAttribute{
                    ColLetter = "N",
                    SrcColLetter = "D"
                }  
            };
        }
    }
}