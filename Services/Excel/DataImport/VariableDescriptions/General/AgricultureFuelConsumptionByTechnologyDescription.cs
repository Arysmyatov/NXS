using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.General
{
    public class AgricultureFuelConsumptionByTechnologyDescription : GeneralVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            Prefix = "Agriculture",            
            CellBg = new XlsCell
            {
                Row = 792,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 799,
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

            Year.CellBg.Row = 791;
            Year.CellEnd.Row = 791;
        }
    }
}