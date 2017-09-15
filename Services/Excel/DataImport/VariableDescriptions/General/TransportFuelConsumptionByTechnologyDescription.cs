using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.General
{
    public class TransportFuelConsumptionByTechnologyDescription  : GeneralVariableAbstract
    {
        private XlsRange _carRange = new XlsRange
        {
            Prefix = "Car",
            CellBg = new XlsCell
            {
                Row = 549,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 556,
                Col = 11
            }
        };

        private XlsRange _hgvRange = new XlsRange
        {
            Prefix = "HGV",            
            CellBg = new XlsCell
            {
                Row = 559,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 566,
                Col = 11
            }
        };

        private XlsRange _lgvRange = new XlsRange
        {
            Prefix = "LGV",            
            CellBg = new XlsCell
            {
                Row = 569,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 576,
                Col = 11
            }
        };


        private XlsRange _busRange = new XlsRange
        {
            Prefix = "Bus",            
            CellBg = new XlsCell
            {
                Row = 579,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 586,
                Col = 11
            }
        };


        private XlsRange _threeWheelerRange = new XlsRange
        {
            Prefix = "Three wheeler",
            CellBg = new XlsCell
            {
                Row = 589,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 591,
                Col = 11
            }
        };


        private XlsRange _twoWheelerRange = new XlsRange
        {
            Prefix = "Two wheeler",
            CellBg = new XlsCell
            {
                Row = 594,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 595,
                Col = 11
            }
        };        
        

        private XlsRange _airRange = new XlsRange
        {
            Prefix = "Air",
            CellBg = new XlsCell
            {
                Row = 598,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 603,
                Col = 11
            }
        };        


        private XlsRange _shipRange = new XlsRange
        {
            Prefix = "Ship",
            CellBg = new XlsCell
            {
                Row = 606,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 609,
                Col = 11
            }
        };
        


        private XlsRange _trainRange = new XlsRange
        {
            Prefix = "Train",
            CellBg = new XlsCell
            {
                Row = 612,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 613,
                Col = 11
            }
        };
                


        public TransportFuelConsumptionByTechnologyDescription()
        {
            VariableDbDescription = new VariableDbDescription
            {
                VariableGroupName = "Transport",
                VariableName = "Fuel consumption by technology"
            };

            XlsRanges = new IXlsRange[] {
                _carRange,
                _hgvRange,
                _lgvRange,
                _busRange,
                _threeWheelerRange,
                _twoWheelerRange,
                _airRange,
                _shipRange,
                _trainRange                
            };

            Year.CellBg.Row = 547;
            Year.CellEnd.Row = 547;
        }
    }
}