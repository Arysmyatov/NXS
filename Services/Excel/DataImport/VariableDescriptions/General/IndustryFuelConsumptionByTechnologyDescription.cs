using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.General
{
    public class IndustryFuelConsumptionByTechnologyDescription : GeneralVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 717,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 723,
                Col = 11
            }
        };


        public IndustryFuelConsumptionByTechnologyDescription()
        {
            VariableDbDescription = new VariableDbDescription
            {
                VariableGroupName = "Industry",
                VariableName = "Fuel consumption by technology"
            };

            XlsRanges = new IXlsRange[] {
                _firstRange
            };

            Year.CellBg.Row  = 716;
            Year.CellEnd.Row = 716;
        }
    }
}