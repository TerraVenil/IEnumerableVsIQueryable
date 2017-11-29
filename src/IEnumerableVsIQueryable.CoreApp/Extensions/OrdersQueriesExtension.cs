using System;
using System.Collections.Generic;
using System.Linq;
using IEnumerableVsIQueryable.CoreApp.Models;

namespace IEnumerableVsIQueryable.CoreApp.Extensions
{
    public static class OrdersQueriesExtension
    {
        public static IEnumerable<Orders> FilterOrders(this IQueryable<Orders> source)
        {
            return source
                .Where(x => x.OrderDate < new DateTime(2017, 7, 12) && x.OrderDate > new DateTime(2017, 7, 4))
                .OrderBy(x => x.ShippedDate)
                .ToList();
        }
    }
}