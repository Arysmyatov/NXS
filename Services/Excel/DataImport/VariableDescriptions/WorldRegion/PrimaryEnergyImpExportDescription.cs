using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.WorldRegion
{
    public class PrimaryEnergyImpExportDescription : WorldVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 126,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 146,
                Col = 11
            }
        };


        public PrimaryEnergyImpExportDescription()
        {
            VariableDbDescription = new VariableDbDescription
            {
                VariableGroupName = "Primary Energy",
                VariableName = "Primary Energy: Imports/Exports"
            };

            XlsRanges = new IXlsRange[] {
                _firstRange
            };

            Year.CellBg.Row  = 125;
            Year.CellEnd.Row = 125;
        }
    }
}