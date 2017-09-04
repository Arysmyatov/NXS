using System.Collections.Generic;
using NXS.Services.Abstract.XlsFormulaUpdater;
using NXS.Services.Excel.FormulaUpdater.XlsVariableAttributesDescriptions;

namespace NXS.Services.Excel.FormulaUpdater.XlsVariableDescriptions
{
    public class TradeImportVariableDescription : XlsVariableDescriptionAbstract
    {
        private XlsRange FirstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 261,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 275,
                Col = 11
            }
        };


        public TradeImportVariableDescription()
        {
            XlsRanges = new XlsRange[] { FirstRange };

            XlsSrcDescription = new XlsSrcDescription
            {
                XlsSheetName = "C_A04a",
                RegionColLetter = "B",
                CommodityColLetter = "C",
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
                RowEnd = 1045
            };

            XlsAttributeVariableDescriptions = new List<IXlsAttributeVariableDescription> {
                new CommodityAttribute {
                    ColLetter = "M",
                    SrcColLetter = "C"
                }
            };
            
        }
    }
}