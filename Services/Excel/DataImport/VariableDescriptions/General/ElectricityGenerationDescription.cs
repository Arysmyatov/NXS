using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.General
{
    public class ElectricityGenerationDescription : GeneralVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 7,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 16,
                Col = 11
            }
        };

        private XlsRange _secondRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 18,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 20,
                Col = 11
            }
        };


        private XlsRange _thirdRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 22,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 24,
                Col = 11
            }
        };



        public ElectricityGenerationDescription()
        {
            VariableDbDescription = new VariableDbDescription
            {
                VariableGroupName = "Electricity",
                VariableName = "Generation"
            };

            XlsRanges = new IXlsRange[] {
                _firstRange,
                _secondRange,
                _thirdRange
            };

            Year.CellBg.Row  = 6;
            Year.CellEnd.Row = 6;
        }
    }
}