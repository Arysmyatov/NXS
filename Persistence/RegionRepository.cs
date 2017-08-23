using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXS.Core;
using NXS.Core.NxsConstants;
using NXS.Core.Models;
using NXS.Extensions;

namespace NXS.Persistence
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NxsDbContext context;

        public RegionRepository(NxsDbContext context)
        {
            this.context = context;
        }

        public async Task<Region> GetRegion(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Regions.FindAsync(id);

            return await context.Regions
              .SingleOrDefaultAsync(r => r.Id == id);
        }


        public async Task<Region> GetRegionByName(string name, bool includeRelated = true)
        {
            return await context.Regions
              .SingleOrDefaultAsync(r => r.Name == name);
        }


        public void Add(Region Region)
        {
            context.Regions.Add(Region);
        }

        public void Remove(Region Region)
        {
            context.Remove(Region);
        }

        public async Task<QueryResult<Region>> GetRegions(RegionQuery queryObj)
        {
            var result = new QueryResult<Region>();

            var query = context.Regions.AsQueryable();

            query = query.ApplyFiltering(queryObj);

            var columnsMap = new Dictionary<string, Expression<Func<Region, object>>>()
            {
                ["parentRegionId"] = v => v.ParentRegionId,
            };
            query = query.ApplyOrdering(queryObj, columnsMap);

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();

            return result;
        }

        public IEnumerable<Region> GetRegions()
        {
            var result = context.Regions.AsEnumerable();
            return result;
        }

        public async Task<Region> GetWorldRegion()
        {
            return await context.Regions.SingleOrDefaultAsync(r => r.Name == RegionConstants.WorldRegionName);
        }
    }
}