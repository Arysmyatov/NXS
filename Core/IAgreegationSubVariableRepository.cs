using System.Collections.Generic;
using System.Threading.Tasks;
using NXS.Core.Models;

namespace NXS.Core
{
    public interface IAgreegationSubVariableRepository
    {
        Task<AgreegationSubVariable> GetAgreegationSubVariable(int id);
        Task<AgreegationSubVariable> GetAgreegationSubVariable(string name); 
        void Add(AgreegationSubVariable Variable);
        void Remove(AgreegationSubVariable Variable);
        Task<QueryResult<AgreegationSubVariable>> GetAgreegationSubVariablesAsync(AgreegationSubVariableQuery filter);
        IEnumerable<AgreegationSubVariable> GetAgreegationSubVariables();
    }
}