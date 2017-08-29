using System.Collections.Generic;
using System.Threading.Tasks;
using NXS.Core.Models;

namespace NXS.Core
{
    public interface IScenarioRepository
    {
        Task<Scenario> GetScenario(int id, bool includeRelated = true); 
        void Add(Scenario region);
        void Remove(Scenario region);
        Task<QueryResult<Scenario>> GetScenarios(ScenarioQuery filter);
        Task<IEnumerable<Scenario>> GetScenarios();
    }
}