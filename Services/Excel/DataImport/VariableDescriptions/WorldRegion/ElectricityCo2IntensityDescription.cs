using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.WorldRegion
{
    public class ElectricityCo2IntensityDescription : WorldVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 30,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 31,
                Col = 11
            }
        };


        public ElectricityCo2IntensityDescription()
        {
            VariableDbDescription = new VariableDbDescription
            {
                VariableGroupName = "Electricity",
                VariableName = "CO2 intensity"
            };

            XlsRanges = new IXlsRange[] {
                _firstRange
            };

            Year.CellBg.Row = 29;
            Year.CellEnd.Row = 29;
        }
    }
}