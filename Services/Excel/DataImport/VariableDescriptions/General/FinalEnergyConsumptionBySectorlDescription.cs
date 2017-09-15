using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.General
{
    public class FinalEnergyConsumptionBySectorlDescription  : GeneralVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 201,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 205,
                Col = 11
            }
        };


        private XlsRange _secondRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 209,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 209,
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

            Year.CellBg.Row  = 200;
            Year.CellEnd.Row = 200;
        }
    }
}