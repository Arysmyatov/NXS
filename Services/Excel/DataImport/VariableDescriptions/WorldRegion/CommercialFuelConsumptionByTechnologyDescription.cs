using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.WorldRegion
{
    public class CommercialFuelConsumptionByTechnologyDescription : WorldVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            Prefix = "Commercial",
            CellBg = new XlsCell
            {
                Row = 870,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 877,
                Col = 11
            }
        };


        public CommercialFuelConsumptionByTechnologyDescription()
        {
            VariableDbDescription = new VariableDbDescription
            {
                VariableGroupName = "Commercial",
                VariableName = "Fuel consumption by technology"
            };

            XlsRanges = new IXlsRange[] {
                _firstRange
            };

            Year.CellBg.Row  = 860;
            Year.CellEnd.Row = 860;
        }
    }
}