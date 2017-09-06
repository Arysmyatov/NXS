using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.General
{
    public class PrimaryEnergyImpExportDescription : GeneralVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 125,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 145,
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

            Year.CellBg.Row  = 124;
            Year.CellEnd.Row = 124;
        }
    }
}