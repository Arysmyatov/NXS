using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.WorldRegion
{
    public class TransportFuelConsumptionByTechnologyDescription  : WorldVariableAbstract
    {

        private XlsRange _carRange = new XlsRange
        {
            Prefix = "Car",
            CellBg = new XlsCell
            {
                Row = 557,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 565,
                Col = 11
            }
        };

        private XlsRange _hgvRange = new XlsRange
        {
            Prefix = "HGV",            
            CellBg = new XlsCell
            {
                Row = 568,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 575,
                Col = 11
            }
        };

        private XlsRange _lgvRange = new XlsRange
        {
            Prefix = "LGV",            
            CellBg = new XlsCell
            {
                Row = 578,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 585,
                Col = 11
            }
        };


        private XlsRange _busRange = new XlsRange
        {
            Prefix = "Bus",            
            CellBg = new XlsCell
            {
                Row = 588,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 595,
                Col = 11
            }
        };


        private XlsRange _threeWheelerRange = new XlsRange
        {
            Prefix = "Three wheeler",
            CellBg = new XlsCell
            {
                Row = 598,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 600,
                Col = 11
            }
        };


        private XlsRange _twoWheelerRange = new XlsRange
        {
            Prefix = "Two wheeler",
            CellBg = new XlsCell
            {
                Row = 603,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 604,
                Col = 11
            }
        };        
        

        private XlsRange _airRange = new XlsRange
        {
            Prefix = "Air",
            CellBg = new XlsCell
            {
                Row = 607,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 612,
                Col = 11
            }
        };        


        private XlsRange _shipRange = new XlsRange
        {
            Prefix = "Ship",
            CellBg = new XlsCell
            {
                Row = 615,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 618,
                Col = 11
            }
        };
        


        private XlsRange _trainRange = new XlsRange
        {
            Prefix = "Train",
            CellBg = new XlsCell
            {
                Row = 621,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 622,
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