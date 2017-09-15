using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.General
{
    public class EmissionesNonCo2EmissionsBySectorDescription : GeneralVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 0,
                Col = 0
            },
            CellEnd = new XlsCell
            {
                Row = 0,
                Col = 0
            }
        };

        private XlsRange _secondRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 0,
                Col = 0
            },
            CellEnd = new XlsCell
            {
                Row = 0,
                Col = 0
            }
        };


        public EmissionesNonCo2EmissionsBySectorDescription()
        {
            VariableDbDescription = new VariableDbDescription
            {
                VariableGroupName = "Emissiones",
                VariableName = "CO2 emissions by sector"
            };

            XlsRanges = new IXlsRange[] {
            };

            Year.CellBg.Row = 0;
            Year.CellEnd.Row = 0;
        }
    }
}