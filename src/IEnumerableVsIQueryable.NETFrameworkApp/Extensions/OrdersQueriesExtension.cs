using System.Data.Entity;
using System.Linq;

namespace IEnumerableVsIQueryable.NETFrameworkApp.Extensions
{
    public static class OrdersQueriesExtension
    {
        public static Orders[] GetOrdersByCustomerId(this IQueryable<Orders> source, string customerId)
        {
            var result = source.Include(x => x.Customers).Where(x => x.CustomerID == customerId).ToArray();
            return result;
        }
    }
}