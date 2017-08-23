using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXS.Core;
using NXS.Core.Models;

namespace NXS.Persistence
{
    public class CommodityRepository : ICommodityRepository
    {
        private readonly NxsDbContext context;

        public CommodityRepository(NxsDbContext context)
        {
            this.context = context;
        }

        public async Task<Commodity> GetCommodity(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Commodities.FindAsync(id);

            return await context.Commodities
              .SingleOrDefaultAsync(p => p.Id == id);
        }


        public async Task<Commodity> GetCommodityByName(string name, bool includeRelated = true)
        {
            return await context.Commodities
              .SingleOrDefaultAsync(p => p.Name == name);
        }


        public void Add(Commodity Commodity)
        {
            context.Commodities.Add(Commodity);
        }

        public void Remove(Commodity Commodity)
        {
            context.Remove(Commodity);
        }        
        
    }
}