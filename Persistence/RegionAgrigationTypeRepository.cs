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
    public class RegionAgrigationTypeRepository : IRegionAgrigationTypeRepository
    {
        private readonly NxsDbContext context;

        public RegionAgrigationTypeRepository(NxsDbContext context)
        {
            this.context = context;
        }


        public async Task<RegionAgrigationType> GetTypeAsync(int id)
        {
            return await context.RegionAgrigationTypes
              .SingleOrDefaultAsync(r => r.Id == id);
        }


        public async Task<RegionAgrigationType> GetTypeAsync(string name)
        {
            return await context.RegionAgrigationTypes
              .SingleOrDefaultAsync(r => r.Name == name);
        }


        public IEnumerable<RegionAgrigationType> GetRegionAgrigationTypes()
        {
            return context.RegionAgrigationTypes.AsEnumerable();
        }        


        public void Add(RegionAgrigationType RegionAgrigationType)
        {
            context.RegionAgrigationTypes.Add(RegionAgrigationType);
        }


        public void Remove(RegionAgrigationType RegionAgrigationType)
        {
            context.Remove(RegionAgrigationType);
        }
    }
}