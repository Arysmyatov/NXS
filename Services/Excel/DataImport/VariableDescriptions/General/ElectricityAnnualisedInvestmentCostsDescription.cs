using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.General
{
    public class ElectricityAnnualisedInvestmentCostsDescription : GeneralVariableAbstract
    {
        private XlsRange _firstRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 77,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 86,
                Col = 11
            }
        };

        private XlsRange _secondRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 88,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 90,
                Col = 11
            }
        };


        private XlsRange _thirdRange = new XlsRange
        {
            CellBg = new XlsCell
            {
                Row = 92,
                Col = 2
            },
            CellEnd = new XlsCell
            {
                Row = 94,
                Col = 11
            }
        };


        public ElectricityAnnualisedInvestmentCostsDescription()
        {
            VariableDbDescription = new VariableDbDescription
            {
                VariableGroupName = "Electricity",
                VariableName = "Annualised investment costs"
            };

            XlsRanges = new IXlsRange[] {
                _firstRange,
                _secondRange,
                _thirdRange
            };

            Year.CellBg.Row  = 76;
            Year.CellEnd.Row = 76;
        }
    }
}