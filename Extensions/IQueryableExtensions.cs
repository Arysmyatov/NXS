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


        public static IQueryable<VariableData> ApplyFiltering(this IQueryable<VariableData> query, VariableDataQuery queryObj)
        {
            if (queryObj.VariableId.HasValue)
                query = query.Where(v => v.VariableId == queryObj.VariableId.Value);

            if (queryObj.RegionId.HasValue)
                query = query.Where(v => v.RegionId == queryObj.RegionId.Value);

            if (queryObj.ScenarioId.HasValue)
                query = query.Where(v => v.ScenarioId == queryObj.ScenarioId.Value);

            if (queryObj.KeyParameterId.HasValue)
                query = query.Where(v => v.KeyParameterId == queryObj.KeyParameterId.Value);

            if (queryObj.KeyParameterLevelId.HasValue)
                query = query.Where(v => v.KeyParameterLevelId == queryObj.KeyParameterLevelId.Value);

            if (!string.IsNullOrEmpty(queryObj.Year))
                query = query.Where(v => v.Year == queryObj.Year);

            #region Attributes

            if (queryObj.ProcessSetId.HasValue)
                query = query.Where(v => v.ProcessSetId == queryObj.ProcessSetId.Value);

            if (queryObj.UserConstraintId.HasValue)
                query = query.Where(v => v.UserConstraintId == queryObj.UserConstraintId.Value);

            if (queryObj.AttributeId.HasValue)
                query = query.Where(v => v.AttributeId == queryObj.AttributeId.Value);

            if (queryObj.CommodityId.HasValue)
                query = query.Where(v => v.CommodityId == queryObj.CommodityId.Value);

            if (queryObj.CommoditySetId.HasValue)
                query = query.Where(v => v.CommoditySetId == queryObj.CommoditySetId.Value);

            #endregion Attributes          

            return query;
        }



        public static IQueryable<SubVariableData> ApplyFiltering(this IQueryable<SubVariableData> query, SubVariableDataQuery queryObj)
        {
            if (queryObj.RegionId.HasValue)
                query = query.Where(v => v.RegionId == queryObj.RegionId.Value);

            if (queryObj.RegionAgrigationTypeId.HasValue)
                query = query.Where(v => v.RegionAgrigationTypeId == queryObj.RegionAgrigationTypeId.Value);            

            if (queryObj.ScenarioId.HasValue)
                query = query.Where(v => v.ScenarioId == queryObj.ScenarioId.Value);                

            if (queryObj.VariableId.HasValue)
                query = query.Where(v => v.VariableId == queryObj.VariableId.Value);

            if (queryObj.KeyParameterId.HasValue)
                query = query.Where(v => v.KeyParameterId == queryObj.KeyParameterId.Value);

            if (queryObj.KeyParameterLevelId.HasValue)
                query = query.Where(v => v.KeyParameterLevelId == queryObj.KeyParameterLevelId.Value);

            if (!string.IsNullOrEmpty(queryObj.Year))
                query = query.Where(v => v.Year == queryObj.Year);

            return query;
        }


        public static IQueryable<SubVariable> ApplyFiltering(this IQueryable<SubVariable> query, SubVariableQuery queryObj)
        {
            if (!string.IsNullOrEmpty(queryObj.Name))
                query = query.Where(v => v.Name == queryObj.Name);

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
            if (queryObj.IsPaging != null && 
               !queryObj.IsPaging.Value)
            {
                return query;
            }

            if (queryObj.Page <= 0)
                queryObj.Page = 1;

            if (queryObj.PageSize <= 0)
                queryObj.PageSize = 10;

            return query.Skip((queryObj.Page - 1) * queryObj.PageSize).Take(queryObj.PageSize);
        }
    }
}