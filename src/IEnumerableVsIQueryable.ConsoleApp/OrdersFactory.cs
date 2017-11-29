using System.Collections.Generic;
using IEnumerableVsIQueryable.CoreApp.Models;

namespace IEnumerableVsIQueryable.ConsoleApp
{
    public static class OrdersFactory
    {
        public static IEnumerable<Orders> CreateOrders()
        {
            return new List<Orders> { new Orders { OrderId = 1 }, new Orders { OrderId = 2 } };
        }
    }
}