using System.Collections.Generic;
using System.Threading.Tasks;
using NXS.Core.Models;

namespace NXS.Core
{
    public interface IRegionRepository
    {
        Task<Region> GetRegion(int id, bool includeRelated = true);
        Task<Region> GetRegionByName(string name, bool includeRelated = true);
        void Add(Region region);
        void Remove(Region region);
        Task<QueryResult<Region>> GetRegionsAsync(RegionQuery filter);
        IEnumerable<Region> GetRegions();
        Task<Region> GetWorldRegion();
    }
}