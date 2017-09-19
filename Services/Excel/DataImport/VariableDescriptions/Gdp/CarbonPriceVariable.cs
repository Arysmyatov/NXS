using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.Gdp
{
    public class CarbonPriceVariable : GdpVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 359,
                Col = 3
            },
            CellEnd = new XlsCell
            {
                Row = 370,
                Col = 11
            }
        };


        public CarbonPriceVariable()
        {
            SheetName = "Global Results";

            VariableDbDescription = new VariableDbDescription
            {
                VariableGroupName = "Bottom",
                VariableName = "Carbon price"
            };

            XlsRanges = new IXlsRange[] {
                _firstRange
            };

            Year.CellBg.Row  = 358;
            Year.CellBg.Col  = 3;
            Year.CellEnd.Row = 358;
            Year.CellEnd.Col  = 11;            
        }
    }
}