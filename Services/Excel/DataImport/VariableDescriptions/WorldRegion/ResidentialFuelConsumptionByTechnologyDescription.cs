using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.WorldRegion
{
    public class ResidentialFuelConsumptionByTechnologyDescription  : WorldVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            Prefix = "Commercial",            
            CellBg = new XlsCell
            {
                Row = 879,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 886,
                Col = 11
            }
        };


        public ResidentialFuelConsumptionByTechnologyDescription()
        {
            VariableDbDescription = new VariableDbDescription
            {
                VariableGroupName = "Residential",
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