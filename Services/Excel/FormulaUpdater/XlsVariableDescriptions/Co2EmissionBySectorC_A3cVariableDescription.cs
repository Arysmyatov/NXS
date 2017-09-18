using System.Collections.Generic;
using NXS.Services.Abstract.XlsFormulaUpdater;
using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.FormulaUpdater.XlsVariableAttributesDescriptions;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.FormulaUpdater.XlsVariableDescriptions
{
    public class Co2EmissionBySectorC_A3cVariableDescription : XlsVariableDescriptionAbstract
    {

        private XlsRange FirstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 220,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 221,
                Col = 11
            }
        };

        private XlsRange SecondRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 230,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 230,
                Col = 11
            }
        };

        private XlsRange ThirdRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 231,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 231,
                Col = 11
            }
        };

        private XlsRange FourthRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 232,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 232,
                Col = 11
            }
        };


        public Co2EmissionBySectorC_A3cVariableDescription()
        {
            XlsRanges = new XlsRange[] { FirstRange, SecondRange, ThirdRange, FourthRange };

            XlsSrcDescription = new XlsSrcDescription
            {
                XlsSheetName = "C_A03c",
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