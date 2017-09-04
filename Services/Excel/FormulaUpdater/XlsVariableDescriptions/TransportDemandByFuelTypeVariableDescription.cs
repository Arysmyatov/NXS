using System.Collections.Generic;
using NXS.Services.Abstract.XlsFormulaUpdater;
using NXS.Services.Excel.FormulaUpdater.XlsVariableAttributesDescriptions;

namespace NXS.Services.Excel.FormulaUpdater.XlsVariableDescriptions
{
    public class TransportDemandByFuelTypeVariableDescription : XlsVariableDescriptionAbstract
    {
        private XlsRange CarRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 549,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 556,
                Col = 11
            }
        };

        private XlsRange HgvRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 559,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 566,
                Col = 11
            }
        };

        private XlsRange LgvRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 569,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 576,
                Col = 11
            }
        };

        private XlsRange BusRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 579,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 586,
                Col = 11
            }
        };

        // Three wheeler
        private XlsRange ThreeWheelerRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 589,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 591,
                Col = 11
            }
        };

        private XlsRange AirWheelerRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 598,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 603,
                Col = 11
            }
        };

        //Ship    
        private XlsRange ShipRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 606,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 609,
                Col = 11
            }
        };

        //Train
        private XlsRange TrainRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 612,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 613,
                Col = 11
            }
        };

        public TransportDemandByFuelTypeVariableDescription()
        {
            XlsRanges = new XlsRange[] { CarRange, HgvRange, LgvRange,
                                    BusRange, ThreeWheelerRange, AirWheelerRange,
                                    ShipRange, TrainRange };

            XlsSrcDescription = new XlsSrcDescription
            {
                XlsSheetName = "C_A08c",
                RegionColLetter = "B",

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
                RowEnd = 1009
            };

            XlsAttributeVariableDescriptions = new List<IXlsAttributeVariableDescription> {
                new ProcessSetAtribute{
                    ColLetter = "N",
                    SrcColLetter = "D"
                },
                new CommodityAttribute{
                    ColLetter = "M",
                    SrcColLetter = "C"
                }
            };            
            
        }
    }
}