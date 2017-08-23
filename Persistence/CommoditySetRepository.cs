using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXS.Core;
using NXS.Core.Models;

namespace NXS.Persistence
{
    public class CommoditySetRepository : ICommoditySetRepository
    {

        private readonly NxsDbContext context;

        public CommoditySetRepository(NxsDbContext context)
        {
            this.context = context;
        }

        public async Task<CommoditySet> GetCommoditySet(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.CommoditySet.FindAsync(id);

            return await context.CommoditySet
              .SingleOrDefaultAsync(p => p.Id == id);
        }


        public async Task<CommoditySet> GetCommoditySetByName(string name, bool includeRelated = true)
        {
            return await context.CommoditySet
              .SingleOrDefaultAsync(p => p.Name == name);
        }


        public void Add(CommoditySet CommoditySet)
        {
            context.CommoditySet.Add(CommoditySet);
        }

        public void Remove(CommoditySet CommoditySet)
        {
            context.Remove(CommoditySet);
        }


    }
}