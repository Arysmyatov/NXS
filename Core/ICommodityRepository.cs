using System.Threading.Tasks;
using NXS.Core.Models;

namespace NXS.Core
{
    public interface ICommodityRepository
    {
        Task<Commodity> GetCommodity(int id, bool includeRelated = true);
        Task<Commodity> GetCommodityByName(string name, bool includeRelated = true);
        void Add(Commodity Commodity);
        void Remove(Commodity Commodity);        
    }
}