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
    public class SubVariableDataRepository : ISubVariableDataRepository
    {

        private readonly NxsDbContext context;

        public SubVariableDataRepository(NxsDbContext context)
        {
            this.context = context;
        }

        public async Task<SubVariableData> GetSubVariableData(int id)
        {
            return await context.SubVariableData.FindAsync(id);
        }

        public void Add(SubVariableData subVariableData)
        {
            context.SubVariableData.Add(subVariableData);
        }

        public void Update(SubVariableData subVariableData)
        {
            context.SubVariableData.Update(subVariableData);
        }        

        public void Remove(SubVariableData subVariable)
        {
            context.Remove(subVariable);
        }

        public IEnumerable<SubVariableData> GetSubVariableData()
        {
            return context.SubVariableData;
        }

        public async Task<QueryResult<SubVariableData>> GetSubVariableData(SubVariableDataQuery queryObj)
        {
            var result = new QueryResult<SubVariableData>();

            var query = context.SubVariableData
              .AsQueryable();

            query = query.ApplyFiltering(queryObj);

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();

            return result;
        }

    }
}