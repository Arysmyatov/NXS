using System.Collections.Generic;
using System.Threading.Tasks;
using NXS.Core.Models;

namespace NXS.Core
{
    public interface IRegionRepository
    {
        Task<Region> GetRegion(int id, bool includeRelated = true); 
        void Add(Region region);
        void Remove(Region region);
        Task<QueryResult<Region>> GetRegions(RegionQuery filter);
    }
}