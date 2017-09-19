using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.Gdp
{
    public class GdpVariable : GdpVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 35,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 46,
                Col = 17
            }
        };


        public GdpVariable()
        {
            VariableDbDescription = new VariableDbDescription
            {
                VariableGroupName = "Top",
                VariableName = "GDP"
            };

            XlsRanges = new IXlsRange[] {
                _firstRange
            };

            Year.CellBg.Row  = 34;
            Year.CellEnd.Row = 34;
        }
    }
}