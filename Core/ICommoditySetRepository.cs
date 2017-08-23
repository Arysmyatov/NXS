using System.Threading.Tasks;
using NXS.Core.Models;

namespace NXS.Core
{
    public interface ICommoditySetRepository
    {
        Task<CommoditySet> GetCommoditySet(int id, bool includeRelated = true);
        Task<CommoditySet> GetCommoditySetByName(string name, bool includeRelated = true);
        void Add(CommoditySet commoditySet);
        void Remove(CommoditySet commoditySet);                
    }
}