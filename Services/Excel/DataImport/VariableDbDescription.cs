using NXS.Services.Abstract.XlsImport;

namespace NXS.Services.Excel.DataImport
{
    public class VariableDbDescription : IVariableDbDescription
    {
        public string VariableGroupName { get; set; }
        public string VariableName { get; set; }
    }
}