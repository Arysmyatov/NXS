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
    public class VariableDataRepository : IVariableDataRepository
    {
        private readonly NxsDbContext context;

        public VariableDataRepository(NxsDbContext context)
        {
            this.context = context;
        }

        public async Task<VariableData> GetData(int id)
        {
            return await context.VariableData
              .SingleOrDefaultAsync(v => v.Id == id);
        }


        public async Task<QueryResult<VariableData>> GetData(VariableDataQuery queryObj)
        {
            var result = new QueryResult<VariableData>();

            var query = context.VariableData
              .AsQueryable();

            query = query.ApplyFiltering(queryObj);

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();

            return result;
        }

        public void Add(VariableData data)
        {
            context.VariableData.Add(data);
        }


        public async Task<decimal> GetSumAsync(VariableDataQuery queryObj)
        {
            queryObj.IsPaging = false;
            decimal sum = 0;

            var result = new QueryResult<VariableData>();

            var query = context.VariableData
              .AsQueryable();

            query = query.ApplyFiltering(queryObj);
            sum = await query.SumAsync(vd => vd.Value);

            return sum;            
        }


        public void Remove(VariableData data)
        {
            context.Remove(data);
        }
    }
}