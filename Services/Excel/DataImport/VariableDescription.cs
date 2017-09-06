using System.Collections.Generic;
using NXS.Services.Abstract.XlsImport;
using NXS.Services.Abstract.XlsStucture;

namespace NXS.Services.Excel.DataImport
{
    public class VariableDescription : IVariableDescription
    {
        public IVariableDbDescription VariableDbDescription { get; set; }
        public ISubVariableDescription SubVariable { get; set; }
        public string SheetName { get; set; }
        public IEnumerable<IXlsRange> XlsRanges { get; set; }
        public IYearDescription Year { get; set; }
    }
}