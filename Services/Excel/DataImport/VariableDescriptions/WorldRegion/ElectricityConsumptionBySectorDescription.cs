using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.WorldRegion
{
    public class ElectricityConsumptionBySectorDescription : WorldVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 37,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 41,
                Col = 11
            }
        };

        private XlsRange _secondRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 43,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 46,
                Col = 11
            }
        };


        public ElectricityConsumptionBySectorDescription()
        {
            VariableDbDescription = new VariableDbDescription
            {
                VariableGroupName = "Electricity",
                VariableName = "Consumption by sector"
            };

            XlsRanges = new IXlsRange[] {
                _firstRange,
                _secondRange
            };

            Year.CellBg.Row = 36;
            Year.CellEnd.Row = 36;
        }
    }
}