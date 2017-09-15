using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.General
{
    public class EmissionesCo2EmissionsBySectorDescription : GeneralVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 216,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 224,
                Col = 11
            }
        };

        private XlsRange _secondRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 226,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 233,
                Col = 11
            }
        };


        public EmissionesCo2EmissionsBySectorDescription()
        {
            VariableDbDescription = new VariableDbDescription
            {
                VariableGroupName = "Emissiones",
                VariableName = "CO2 emissions by sector"
            };

            XlsRanges = new IXlsRange[] {
                _firstRange,
                _secondRange
            };

            Year.CellBg.Row = 215;
            Year.CellEnd.Row = 215;
        }
    }
}