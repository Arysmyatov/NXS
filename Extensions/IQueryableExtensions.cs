using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NXS.Core;
using NXS.Core.Models;

namespace NXS.Extensions
{
    public static class IQueryableExtensions
    {

      public static IQueryable<Region> ApplyFiltering(this IQueryable<Region> query, RegionQuery queryObj)
      {
        if (queryObj.ParentRegionId.HasValue)
          query = query.Where(v => v.ParentRegionId == queryObj.ParentRegionId.Value);

        return query; 
      }


      public static IQueryable<Variable> ApplyFiltering(this IQueryable<Variable> query, VariableQuery queryObj)
      {
        if (queryObj.VariableGroupId.HasValue)
          query = query.Where(v => v.VariableGroupId == queryObj.VariableGroupId.Value);

        return query; 
      }


      public static IQueryable<SubVariable> ApplyFiltering(this IQueryable<SubVariable> query, SubVariableQuery queryObj)
      {
        return query; 
      }
      

      public static IQueryable<Scenario> ApplyFiltering(this IQueryable<Scenario> query, ScenarioQuery queryObj)
      {
        return query; 
      }      


      public static IQueryable<Data> ApplyFiltering(this IQueryable<Data> query, DataQuery queryObj)
      {
        if (queryObj.RegionId.HasValue)
          query = query.Where(v => v.RegionId == queryObj.RegionId.Value);

        if (queryObj.ScenarioId.HasValue)
          query = query.Where(v => v.ScenarioId == queryObj.ScenarioId.Value);

        if (queryObj.VariableId.HasValue)
          query = query.Where(v => v.VariableId == queryObj.VariableId.Value);

        if (queryObj.KeyParameterId.HasValue)
          query = query.Where(v => v.KeyParameterId == queryObj.KeyParameterId.Value);

        if (queryObj.KeyParameterLevelId.HasValue)
          query = query.Where(v => v.KeyParameterLevelId == queryObj.KeyParameterLevelId.Value);

        return query; 
      }      

      public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObj, Dictionary<string, Expression<Func<T, object>>> columnsMap)
      {
        if (String.IsNullOrWhiteSpace(queryObj.SortBy) || !columnsMap.ContainsKey(queryObj.SortBy))
          return query;

        if (queryObj.IsSortAscending)
          return query.OrderBy(columnsMap[queryObj.SortBy]);
        else
          return query.OrderByDescending(columnsMap[queryObj.SortBy]);
      }

      public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObj) 
      {
         if (queryObj.Page <= 0)
          queryObj.Page = 1; 
          
         if (queryObj.PageSize <= 0)
          queryObj.PageSize = 10; 

         return query.Skip((queryObj.Page - 1) * queryObj.PageSize).Take(queryObj.PageSize);
      }
    }
}