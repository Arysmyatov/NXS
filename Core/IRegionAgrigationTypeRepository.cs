using System.Collections.Generic;
using System.Threading.Tasks;
using NXS.Core.Models;

namespace NXS.Core
{
    public interface IRegionAgrigationTypeRepository
    {
        Task<RegionAgrigationType> GetTypeAsync(int id);
        Task<RegionAgrigationType> GetTypeAsync(string name);
        void Add(RegionAgrigationType regionAgrigationType);
        void Remove(RegionAgrigationType regionAgrigationType);
        IEnumerable<RegionAgrigationType> GetRegionAgrigationTypes();
    }
}