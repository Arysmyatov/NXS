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
    public class SubVariableRepository : ISubVariableRepository
    {
        private readonly NxsDbContext context;

        public SubVariableRepository(NxsDbContext context)
        {
            this.context = context;
        }

        public async Task<SubVariable> GetSubVariable(int id)
        {
            return await context.SubVariables.FindAsync(id);
        }

        public void Add(SubVariable subVariable)
        {
            context.SubVariables.Add(subVariable);
        }

        public void Remove(SubVariable subVariable)
        {
            context.Remove(subVariable);
        }

        public async Task<QueryResult<SubVariable>> GetSubVariables(SubVariableQuery queryObj)
        {
            var result = new QueryResult<SubVariable>();

            var query = context.SubVariables
              .AsQueryable();

            query = query.ApplyFiltering(queryObj);

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();

            return result;
        }

    }
}