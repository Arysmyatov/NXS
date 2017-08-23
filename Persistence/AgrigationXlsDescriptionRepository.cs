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
    public class AgrigationXlsDescriptionRepository : IAgrigationXlsDescriptionRepository
    {
        private readonly NxsDbContext context;

        public AgrigationXlsDescriptionRepository(NxsDbContext context)
        {
            this.context = context;
        }

        public async Task<AgrigationXlsDescription> GetDescription(int id)
        {
            return await context.AgrigationXlsDescriptions
              .SingleOrDefaultAsync(v => v.Id == id);
        }


        public IEnumerable<AgrigationXlsDescription> GetDescriptions()
        {
            return GetDescriptions(RegionConstants.Types.ByRegion);
        }


        public IEnumerable<AgrigationXlsDescription> GetWorldDescriptions()
        {
            return GetDescriptions(RegionConstants.Types.World);
        }

        
        public void Add(AgrigationXlsDescription AgrigationXlsDescription)
        {
            context.AgrigationXlsDescriptions.Add(AgrigationXlsDescription);
        }


        public void Remove(AgrigationXlsDescription AgrigationXlsDescription)
        {
            context.Remove(AgrigationXlsDescription);
        }


        private IEnumerable<AgrigationXlsDescription> GetDescriptions(string regionTypeName)
        {
            return context.AgrigationXlsDescriptions.Where(a => a.RegionAgrigationType.Name == regionTypeName);
        }
        
    }
}