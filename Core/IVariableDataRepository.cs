using System.Collections.Generic;
using System.Threading.Tasks;
using NXS.Core.Models;

namespace NXS.Core
{
    public interface IVariableDataRepository
    {
        Task<VariableData> GetData(int id);
        Task<QueryResult<VariableData>> GetData(VariableDataQuery queryObj);
        void Add(VariableData Variable);
        Task<decimal> GetSumAsync(VariableDataQuery queryObj);
        void Remove(VariableData Variable);
    }
}