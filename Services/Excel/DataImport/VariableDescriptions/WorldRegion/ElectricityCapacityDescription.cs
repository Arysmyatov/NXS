using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.WorldRegion
{
    public class ElectricityCapacityDescription : WorldVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 53,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 62,
                Col = 11
            }
        };

        private XlsRange _secondRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 64,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 66,
                Col = 11
            }
        };

        private XlsRange _thirdRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 68,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 70,
                Col = 11
            }
        };


        public ElectricityCapacityDescription()
        {
            VariableDbDescription = new VariableDbDescription
            {
                VariableGroupName = "Electricity",
                VariableName = "Capacity"
            };

            XlsRanges = new IXlsRange[] {
                _firstRange,
                _secondRange,
                _thirdRange
            };

            Year.CellBg.Row = 52;
            Year.CellEnd.Row = 52;
        }
    }
}