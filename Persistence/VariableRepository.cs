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
  public class VariableRepository : IVariableRepository
  {
    private readonly NxsDbContext context;

    public VariableRepository(NxsDbContext context)
    {
        this.context = context;
    }

    public async Task<Variable> GetVariable(int id, bool includeRelated = true)
    {
        if (!includeRelated)
          return await context.Variables.FindAsync(id);

        return await context.Variables
          .Include(v => v.VariableXls)
          .SingleOrDefaultAsync(v => v.Id == id);
    }

    public void Add(Variable Variable) 
    {
      context.Variables.Add(Variable);
    }

    public void Remove(Variable Variable)
    {
      context.Remove(Variable);
    }

    public async Task<QueryResult<Variable>> GetVariables(VariableQuery queryObj)
    {
      var result = new QueryResult<Variable>();

      var query = context.Variables
        .Include(v => v.VariableXls)
        .AsQueryable();

      query = query.ApplyFiltering(queryObj);

      var columnsMap = new Dictionary<string, Expression<Func<Variable, object>>>()
      {
        ["variableGroup"] = v => v.VariableGroupId
      };
      query = query.ApplyOrdering(queryObj, columnsMap);
      
      result.TotalItems = await query.CountAsync();

      query = query.ApplyPaging(queryObj);

      result.Items = await query.ToListAsync();

      return result; 
    }

  }
}