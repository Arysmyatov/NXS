using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.General
{
    public class FinalEnergyConsumptionByFuelDescription: GeneralVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 184,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 190,
                Col = 11
            }
        };

        private XlsRange _secondRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 192,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 194,
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

            Year.CellBg.Row  = 183;
            Year.CellEnd.Row = 183;
        }
    }
}