using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.Gdp
{
    public class SystemCostsVariable: GdpVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 721,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 736,
                Col = 11
            }
        };


        public SystemCostsVariable()
        {
            SheetName = "Global Results";

            VariableDbDescription = new VariableDbDescription
            {
                VariableGroupName = "Bottom",
                VariableName = "System costs"
            };

            XlsRanges = new IXlsRange[] {
                _firstRange
            };

            Year.CellBg.Row  = 720;
            Year.CellBg.Col  = 3;
            Year.CellEnd.Row = 720;
            Year.CellEnd.Col  = 11;
        }
    }
}