using System.Collections.Generic;
using NXS.Services.Abstract.XlsStucture;

namespace NXS.Services.Abstract.XlsImport
{
    public interface IVariableDescription
    {
        IVariableDbDescription VariableDbDescription { get; set; }
        ISubVariableDescription SubVariable { get; set; }
        string SheetName {get;set;}
        IEnumerable<IXlsRange> XlsRanges { get; set; }
        IYearDescription Year { get; set; }
    }
}