using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.WorldRegion
{
    public class AgricultureFuelConsumptionByTechnologyDescription : WorldVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            Prefix = "Agriculture",
            CellBg = new XlsCell
            {
                Row = 861,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 868,
                Col = 11
            }
        };


        public AgricultureFuelConsumptionByTechnologyDescription()
        {
            VariableDbDescription = new VariableDbDescription
            {
                VariableGroupName = "Agriculture",
                VariableName = "Fuel consumption by technology"
            };

            XlsRanges = new IXlsRange[] {
                _firstRange
            };

            Year.CellBg.Row = 860;
            Year.CellEnd.Row = 860;
        }
    }
}