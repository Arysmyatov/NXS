using System.Collections.Generic;
using System.Threading.Tasks;
using NXS.Core.Models;

namespace NXS.Core
{
    public interface IVariableGroupRepository
    {
        Task<VariableGroup> GetVariableGroup(int id, bool includeRelated = true); 
        void Add(VariableGroup VariableGroup);
        void Remove(VariableGroup VariableGroup);
        Task<QueryResult<VariableGroup>> GetVariableGroups(VariableGroupQuery filter);
    }
}