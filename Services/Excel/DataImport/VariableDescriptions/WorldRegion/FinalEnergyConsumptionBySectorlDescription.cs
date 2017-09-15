using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.WorldRegion
{
    public class FinalEnergyConsumptionBySectorlDescription : WorldVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 210,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 214,
                Col = 11
            }
        };

        private XlsRange _secondRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 218,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 218,
                Col = 11
            }
        };


        public FinalEnergyConsumptionBySectorlDescription()
        {
            VariableDbDescription = new VariableDbDescription
            {
                VariableGroupName = "Final Energy Consumption",
                VariableName = "Final Energy Consumption : By sector"
            };

            XlsRanges = new IXlsRange[] {
                _firstRange,
                _secondRange
            };

            Year.CellBg.Row  = 209;
            Year.CellEnd.Row = 209;
        }
    }
}