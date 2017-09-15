using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.General
{
    public class CommercialFuelConsumptionByTechnologyDescription : GeneralVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            Prefix = "Commercial",            
            CellBg = new XlsCell
            {
                Row = 801,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 808,
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

            Year.CellBg.Row = 791;
            Year.CellEnd.Row = 791;
        }
    }
}