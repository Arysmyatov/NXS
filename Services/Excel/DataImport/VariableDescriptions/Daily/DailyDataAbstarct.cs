using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.Daily
{
    public abstract class DailyDataAbstarct
    {
        public int YearCol { get; set; }
        public int MonthRow { get; set; }
        public int DayRow { get; set; }
        public int VariableCol { get; set; }
        public string SheetName { get; set; }

        public XlsRange Range = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 901,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 370,
                Col = 11
            }
        };
        
    }
}