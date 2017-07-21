using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXS.Core;
using NXS.Core.Models;

namespace NXS.Persistence
{
  public class VariableGroupRepository : IVariableGroupRepository
  {
    private readonly NxsDbContext context;

    public VariableGroupRepository(NxsDbContext context)
    {
        this.context = context;
    }

    public async Task<VariableGroup> GetVariableGroup(int id, bool includeRelated = true)
    {
        if (!includeRelated)
          return await context.VariableGroups.FindAsync(id);

        return await context.VariableGroups
          .Include(v => v.Variables)
          .SingleOrDefaultAsync(v => v.Id == id);
    }

    public void Add(VariableGroup VariableGroup) 
    {
      context.VariableGroups.Add(VariableGroup);
    }

    public void Remove(VariableGroup VariableGroup)
    {
      context.Remove(VariableGroup);
    }

    public async Task<QueryResult<VariableGroup>> GetVariableGroups(VariableGroupQuery queryObj)
    {
      var result = new QueryResult<VariableGroup>();

      var query = context.VariableGroups
        .Include(v => v.Variables)
        .AsQueryable();
      
      result.TotalItems = await query.CountAsync();
      result.Items = await query.ToListAsync();

      return result; 
    }

  }
}