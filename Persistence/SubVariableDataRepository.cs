using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXS.Core;
using NXS.Core.Models;
using NXS.Core.NxsConstants;
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

        public void Remove(SubVariableDataQuery queryObj)
        {
            queryObj.IsPaging = false;
            var query = context.SubVariableData
              .AsQueryable();
            query = query.ApplyFiltering(queryObj);

            context.SubVariableData.RemoveRange(query);
        }

        public void RemoveGeneral(SubVariableDataQuery queryObj)
        {
            queryObj.IsPaging = false;
            var query = context.SubVariableData
              .AsQueryable();
            query = query.ApplyFiltering(queryObj);
            query = query.Where(sv => sv.Region.Name != RegionConstants.WorldRegionName &&
                                      sv.Variable.Name != NxsVariablesConstants.Variables.Gdp &&
                                      sv.Variable.Name != NxsVariablesConstants.Variables.Population);

            context.SubVariableData.RemoveRange(query);
        }


        public void RemoveWorld(SubVariableDataQuery queryObj)
        {
            queryObj.IsPaging = false;
            var query = context.SubVariableData
              .AsQueryable();
            query = query.ApplyFiltering(queryObj);
            query = query.Where(sv => sv.Region.Name == RegionConstants.WorldRegionName &&
                                      sv.Variable.Name != NxsVariablesConstants.Variables.Gdp &&
                                      sv.Variable.Name != NxsVariablesConstants.Variables.Population);

            context.SubVariableData.RemoveRange(query);
        }


        public void RemoveGdp(SubVariableDataQuery queryObj)
        {
            queryObj.IsPaging = false;
            var query = context.SubVariableData
              .AsQueryable();
            query = query.ApplyFiltering(queryObj);
            query = query.Where(sv => sv.Variable.Name == NxsVariablesConstants.Variables.Gdp);

            context.SubVariableData.RemoveRange(query);
        }


        public void RemovePopulation(SubVariableDataQuery queryObj)
        {
            queryObj.IsPaging = false;
            var query = context.SubVariableData
              .AsQueryable();
            query = query.ApplyFiltering(queryObj);
            query = query.Where(sv => sv.Variable.Name == NxsVariablesConstants.Variables.Population);

            context.SubVariableData.RemoveRange(query);
        }


        public IEnumerable<SubVariableData> GetSubVariableData()
        {
            return context.SubVariableData;
        }

        public async Task<QueryResult<SubVariableData>> GetSubVariableData(SubVariableDataQuery queryObj, bool includeRelated = false)
        {
            var result = new QueryResult<SubVariableData>();

            var query = getSubVariableData(queryObj, includeRelated);
            result.TotalItems = await query.CountAsync();
            result.Items = await query.ToListAsync();

            return result;
        }


        public async Task<QueryResult<SubVariableData>> GetSubVariableDataWithoutGdp(SubVariableDataQuery queryObj, bool includeRelated = false)
        {
            var result = new QueryResult<SubVariableData>();

            var query = getSubVariableData(queryObj, includeRelated);
            query = query.Where(sv => sv.Variable.Name != NxsVariablesConstants.Variables.Gdp);

            result.TotalItems = await query.CountAsync();
            result.Items = await query.ToListAsync();

            return result;
        }


        private IQueryable<SubVariableData> getSubVariableData(SubVariableDataQuery queryObj, bool includeRelated = false)
        {
            var query = context.SubVariableData
              .AsQueryable();
            query = query.ApplyFiltering(queryObj);
            query = query.ApplyPaging(queryObj);
            if (includeRelated)
            {
                query = query.Include(sv => sv.SubVariable);
            }

            return query;
        }

    }
}