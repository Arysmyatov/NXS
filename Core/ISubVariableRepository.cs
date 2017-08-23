using System.Collections.Generic;
using System.Threading.Tasks;
using NXS.Core.Models;

namespace NXS.Core
{
    public interface ISubVariableRepository
    {
        Task<SubVariable> GetSubVariable(int id); 
        Task<SubVariable> GetSubVariable(string name); 
        void Add(SubVariable Variable);
        void Remove(SubVariable Variable);
        Task<QueryResult<SubVariable>> GetSubVariables(SubVariableQuery filter);
    }
}