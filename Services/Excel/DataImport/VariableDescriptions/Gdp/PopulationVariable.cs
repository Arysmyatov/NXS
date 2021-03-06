using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.Gdp
{
    public class PopulationVariable: GdpVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 3,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 46,
                Col = 17
            }
        };


        public PopulationVariable()
        {
            VariableDbDescription = new VariableDbDescription
            {
                VariableGroupName = "Top",
                VariableName = "Population"
            };

            XlsRanges = new IXlsRange[] {
                _firstRange
            };

            Year.CellBg.Row  = 2;
            Year.CellEnd.Row = 2;
        }
    }
}