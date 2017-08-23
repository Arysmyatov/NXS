using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXS.Core;
using NXS.Core.Models;
using NXS.Extensions;

namespace NXS.Persistence
{
    public class VariableXlsDescriptionRepository : IVariableXlsDescriptionRepository
    {
        private readonly NxsDbContext context;

        public VariableXlsDescriptionRepository(NxsDbContext context)
        {
            this.context = context;
        }

        public async Task<VariableXlsDescription> GetVariableXlsDescription(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.VariableXlsDescriptions.FindAsync(id);

            return await context.VariableXlsDescriptions
              .SingleOrDefaultAsync(v => v.Id == id);
        }


        public IEnumerable<VariableXlsDescription> GetVariableXlsDescriptions()
        {
            var result = new QueryResult<VariableXlsDescription>();

            var list = context.VariableXlsDescriptions;

            return list;
        }


        public void Add(VariableXlsDescription VariableXlsDescription)
        {
            context.VariableXlsDescriptions.Add(VariableXlsDescription);
        }
        

        public void Remove(VariableXlsDescription VariableXlsDescription)
        {
            context.Remove(VariableXlsDescription);
        }
    }
}