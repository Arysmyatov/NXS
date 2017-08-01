using NXS.Core.Models;

namespace NXS.Core
{
    public interface IVariableXlsRepository
    {
        VariableXls GetVariableXlsAsync(int variableId, int rerionTypeId);
        void Add(VariableXls xlsUpload);
        void Update(VariableXls xlsUpload);
    }
}