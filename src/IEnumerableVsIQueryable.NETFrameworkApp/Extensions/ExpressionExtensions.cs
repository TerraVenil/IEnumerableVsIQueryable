using System;
using System.Linq.Expressions;

namespace IEnumerableVsIQueryable.NETFrameworkApp.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<TSource, TResult>> UseAsConstant<TSource, TResult, TConstant>(this Expression<Func<TSource, TConstant, TResult>> source, TConstant constant)
        {
            var body = source.Body.Replace(source.Parameters[1], Expression.Constant(constant));
            return Expression.Lambda<Func<TSource, TResult>>(body, source.Parameters[0]);
        }

        private static Expression Replace(this Expression source, Expression input, Expression output)
        {
            return new ReplaceVisitor(input, output).Visit(source);
        }

        internal class ReplaceVisitor : ExpressionVisitor
        {
            private readonly Expression _from, _to;

            public ReplaceVisitor(Expression from, Expression to)
            {
                _from = from;
                _to = to;
            }

            public override Expression Visit(Expression node)
            {
                return node == _from ? _to : base.Visit(node);
            }
        }
    }
}