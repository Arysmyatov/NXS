using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.WorldRegion
{
    public class IndustryFuelConsumptionByTechnologyDescription : WorldVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 786,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 792,
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

            Year.CellBg.Row = 785;
            Year.CellEnd.Row = 785;
        }

    }
}