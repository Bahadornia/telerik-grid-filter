using Core.Dtos;
using Core.Enums;
using System.Linq.Expressions;

namespace Common
{
    public static class Extensions
    {
        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, CompositeFilterDescriptor filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            return query.Where(Filter<T>(filter));
        }
        public static Expression<Func<T, bool>> Filter<T>(CompositeFilterDescriptor filter)
        {
            Expression<Func<T, bool>> result = row => true;
            foreach (var item in filter.Filters)
            {
                try
                {
                    var parameterExpression = Expression.Parameter(typeof(T));
                    var property = Expression.Property(parameterExpression, item?.Field);
                    var param = Expression.Parameter(typeof(T), "row");
                    var body = Expression.AndAlso(Expression.Invoke(result, param), Expression.Invoke(result, param));
                    if (item.Operator == FilterOperator.Contains)
                    {
                        var constant = Expression.Constant(item.value.ToString());
                        var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                        var methodCall = Expression.Call(property, containsMethod, constant);
                        var lambda = Expression.Lambda(methodCall, parameterExpression);
                        body = Expression.AndAlso(body, Expression.Invoke(lambda, param));
                    }
                    var binaryExpression = GetBinaryExpression(property, item);
                    body = Expression.AndAlso
                        (
                        body,
                        Expression.Invoke(Expression.Lambda(binaryExpression, parameterExpression), param)
                        );

                    result = Expression.Lambda<Func<T, bool>>(body, param);
                }
                catch(Exception ex)
                {

                }
               



            }
            return result;
        }

        public static BinaryExpression GetBinaryExpression(MemberExpression property, FilterDescriptor item)
        {
           
            try
            {
                if (item.Field == "creationDate")
                {
                    var temp = Convert.ToDateTime(item.value.ToString());
                    var constant = Expression.Constant(temp);
                    return item.Operator switch
                    {
                        FilterOperator.Lt => Expression.LessThan(property, constant),
                        FilterOperator.Lte => Expression.LessThanOrEqual(property, constant),
                        FilterOperator.Gt => Expression.GreaterThan(property, constant),
                        FilterOperator.Gte => Expression.GreaterThanOrEqual(property, constant),
                    };
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return null;
            
        }

    }
}