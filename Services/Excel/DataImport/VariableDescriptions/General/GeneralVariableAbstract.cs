using System.Collections.Generic;
using NXS.Services.Abstract.XlsImport;
using NXS.Services.Abstract.XlsStucture;
using NXS.Services.Excel.Structure;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.General
{
    public abstract class GeneralVariableAbstract : IVariableDescription
    {
        public IVariableDbDescription VariableDbDescription { get; set; }
        public ISubVariableDescription SubVariable
        {
            get => new SubVariableDescription
            {
                Col = 2
            }; set => throw new System.NotImplementedException();
        }
        public string SheetName { get => "By region"; set => throw new System.NotImplementedException(); }
        public IEnumerable<IXlsRange> XlsRanges { get; set; }
        public IYearDescription Year { get; set; }

        public GeneralVariableAbstract()
        {
            Year = new YearDescription
            {
                CellBg = new XlsCell { Col = 3 },
                CellEnd = new XlsCell { Col = 11 }
            };
        }
    }
}