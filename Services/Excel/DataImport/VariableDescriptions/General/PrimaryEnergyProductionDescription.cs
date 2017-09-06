using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.General
{
    public class PrimaryEnergyProductionDescription : GeneralVariableAbstract
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
                Row = 24,
                Col = 11
            }
        };


        public PrimaryEnergyProductionDescription()
        {
            VariableDbDescription = new VariableDbDescription
            {
                VariableGroupName = "Primary Energy",
                VariableName = "Primary Energy: Production"
            };

            XlsRanges = new IXlsRange[] {
                _firstRange
            };

            Year.CellBg.Row  = 6;
            Year.CellEnd.Row = 6;
        }
    }
}