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
  public class DataRepository : IDataRepository
  {
    private readonly NxsDbContext context;

    public DataRepository(NxsDbContext context)
    {
        this.context = context;
    }

    public async Task<Data> GetData(int id, bool includeRelated = true)
    {
        if (!includeRelated)
          return await context.Data.FindAsync(id);

        return await context.Data
          .Include(v => v.SubVariable)
          .SingleOrDefaultAsync(v => v.Id == id);
    }

    public void Add(Data data) 
    {
      context.Data.Add(data);
    }

    public void Remove(Data data)
    {
      context.Remove(data);
    }

    public async Task<QueryResult<Data>> GetData(DataQuery queryObj)
    {
      var result = new QueryResult<Data>();

      var query = context.Data
        .Include(v => v.SubVariable)
        .AsQueryable();

      query = query.ApplyFiltering(queryObj);
     
      result.TotalItems = await query.CountAsync();

      query = query.ApplyPaging(queryObj);

      result.Items = await query.ToListAsync();

      return result; 
    }

  }
}