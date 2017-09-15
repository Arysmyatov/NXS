using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.WorldRegion
{
    public class FinalEnergyConsumptionByFuelDescription : WorldVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 193,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 199,
                Col = 11
            }
        };

        private XlsRange _secondRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 201,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 203,
                Col = 11
            }
        };


        public FinalEnergyConsumptionByFuelDescription()
        {
            VariableDbDescription = new VariableDbDescription
            {
                VariableGroupName = "Final Energy Consumption",
                VariableName = "Final Energy Consumption : By fuel"
            };

            XlsRanges = new IXlsRange[] {
                _firstRange,
                _secondRange
            };

            Year.CellBg.Row  = 192;
            Year.CellEnd.Row = 192;
        }
    }
}