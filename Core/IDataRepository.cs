using System.Collections.Generic;
using System.Threading.Tasks;
using NXS.Core.Models;

namespace NXS.Core
{
    public interface IDataRepository
    {
        Task<Data> GetData(int id, bool includeRelated = true); 
        void Add(Data data);
        void Remove(Data data);
        Task<QueryResult<Data>> GetData(DataQuery filter);
    }
}