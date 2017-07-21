using System.Collections.Generic;
using System.Threading.Tasks;
using NXS.Core.Models;

namespace NXS.Core
{
    public interface IVariableRepository
    {
        Task<Variable> GetVariable(int id, bool includeRelated = true); 
        void Add(Variable Variable);
        void Remove(Variable Variable);
        Task<QueryResult<Variable>> GetVariables(VariableQuery filter);
    }
}