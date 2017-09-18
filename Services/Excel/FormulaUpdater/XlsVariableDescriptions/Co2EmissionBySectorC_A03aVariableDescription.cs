using System.Collections.Generic;
using NXS.Services.Abstract.XlsFormulaUpdater;
using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.FormulaUpdater.XlsVariableAttributesDescriptions;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.FormulaUpdater.XlsVariableDescriptions
{
    public class Co2EmissionBySectorC_A03aVariableDescription  : XlsVariableDescriptionAbstract
    {

        private XlsRange FirstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 216,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 218,
                Col = 11
            }
        };


        public Co2EmissionBySectorC_A03aVariableDescription()
        {
            XlsRanges = new XlsRange[] { FirstRange };

            XlsSrcDescription = new XlsSrcDescription
            {
                XlsSheetName = "C_A03a",
                RegionColLetter = "B",
                CommoditySetColLetter = "C",

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
                new CommoditySetAttribute {
                    ColLetter = "M",
                    SrcColLetter = "C"
                }
            };            
            
        }
    }
}