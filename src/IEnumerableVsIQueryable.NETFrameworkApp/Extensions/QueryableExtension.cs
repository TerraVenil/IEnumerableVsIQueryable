using System;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace IEnumerableVsIQueryable.NETFrameworkApp.Extensions
{
    public static class QueryableExtension
    {
        public static string StartWith(this IQueryable<Services> source, string searchText)
        {
            var result = source.Where(x => x.Name.StartsWith(searchText)).Select(x => x.Name).FirstOrDefault();
            return result;
        }

        public static Services[] ContainsByName(this IQueryable<Services> source, string searchText)
        {
            var result = source.Where(x => x.Name.Contains(searchText)).ToArray();
            return result;
        }

        public static Services[] ContainsByNameAsConstant(this IQueryable<Services> source, string searchText)
        {
            Expression<Func<Services, string, bool>> predicate = (x, t) => x.Name.Contains(t);
            var result = source.Where(predicate.UseAsConstant(searchText)).ToArray();
            return result;
        }

        public static Services[] ContainsByNameWithLike(this IQueryable<Services> source, string searchText)
        {
            var result = source.Where(x => SqlMethods.Like(x.Name, searchText)).ToArray();
            return result;
        }
    }
}