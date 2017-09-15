using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.General
{
    public class ResidentialFuelConsumptionByTechnologyDescription : GeneralVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            Prefix = "Commercial",            
            CellBg = new XlsCell
            {
                Row = 810,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 817,
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

            Year.CellBg.Row  = 791;
            Year.CellEnd.Row = 791;
        }
    }
}