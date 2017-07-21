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
  public class ScenarioRepository : IScenarioRepository
  {
    private readonly NxsDbContext context;

    public ScenarioRepository(NxsDbContext context)
    {
        this.context = context;
    }

    public async Task<Scenario> GetScenario(int id, bool includeRelated = true)
    {
        if (!includeRelated)
          return await context.Scenarios.FindAsync(id);

        return await context.Scenarios
          .SingleOrDefaultAsync(r => r.Id == id);
    }

    public void Add(Scenario sceanrio) 
    {
      context.Scenarios.Add(sceanrio);
    }

    public void Remove(Scenario scenario)
    {
      context.Remove(scenario);
    }

    public async Task<QueryResult<Scenario>> GetScenarios(ScenarioQuery queryObj)
    {
      var result = new QueryResult<Scenario>();

      var query = context.Scenarios.AsQueryable();

      query = query.ApplyFiltering(queryObj);
      
      result.TotalItems = await query.CountAsync();

      query = query.ApplyPaging(queryObj);

      result.Items = await query.ToListAsync();

      return result; 
    }
  }
}