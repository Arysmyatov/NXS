using System.Collections.Generic;
using System.Threading.Tasks;
using NXS.Core.Models;

namespace NXS.Core
{
    public interface ISubVariableDataRepository
    {
        Task<SubVariableData> GetSubVariableData(int id); 
        void Add(SubVariableData subVariableData);
        void Update(SubVariableData subVariableData);
        void Remove(SubVariableData subVariableData);
        void RemoveGeneral(SubVariableDataQuery queryObj);
        void RemoveWorld(SubVariableDataQuery queryObj);
        IEnumerable<SubVariableData> GetSubVariableData();
        Task<QueryResult<SubVariableData>> GetSubVariableData(SubVariableDataQuery queryObj, bool includeRelated = false);
        Task<QueryResult<SubVariableData>> GetSubVariableDataWithoutGdp(SubVariableDataQuery queryObj, bool includeRelated = false);
    }
}