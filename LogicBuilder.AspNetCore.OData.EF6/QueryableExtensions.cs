using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using LogicBuilder.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace LogicBuilder.OData.EF6
{
    public static class QueryableExtensions
    {
        public static ICollection<TModel> Get<TModel, TData>(this IQueryable<TData> query, IMapper mapper, ODataQueryOptions<TModel> options)
            where TModel : class
        {
            Expression<Func<TModel, object>>[] includeExpressions = options.SelectExpand.GetIncludes().BuildIncludes<TModel>().ToArray();
            Expression<Func<TModel, bool>> filter = options.Filter.ToFilterExpression<TModel>();
            Expression<Func<IQueryable<TModel>, IQueryable<TModel>>> queryableExpression = options.GetQueryableExpression();

            ICollection<TModel> collection = query.Get(mapper, filter, queryableExpression, includeExpressions);

            return collection;
        }

        public static ICollection<TModel> Get<TModel, TData>(this IQueryable<TData> query, IMapper mapper,
            Expression<Func<TModel, bool>> filter = null,
            Expression<Func<IQueryable<TModel>, IQueryable<TModel>>> queryFunc = null,
            IEnumerable<Expression<Func<TModel, object>>> includeProperties = null)
        {
            //Map the expressions
            Expression<Func<TData, bool>> f = mapper.MapExpression<Expression<Func<TData, bool>>>(filter);
            Func<IQueryable<TData>, IQueryable<TData>> mappedQueryFunc = mapper.MapExpression<Expression<Func<IQueryable<TData>, IQueryable<TData>>>>(queryFunc)?.Compile();
            ICollection<Expression<Func<TData, object>>> includes = mapper.MapIncludesList<Expression<Func<TData, object>>>(includeProperties);

            if (filter != null)
                query = query.Where(f);

            if (includes != null)
                query = includes.Aggregate(query, (q, next) => q.Include(next));

            //Call the store
            ICollection<TData> result = mappedQueryFunc != null ? mappedQueryFunc(query).ToList() : query.ToList();

            //Map and return the data
            return mapper.Map<IEnumerable<TData>, IEnumerable<TModel>>(result).ToList();
        }
    }
}
