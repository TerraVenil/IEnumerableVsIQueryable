using System;
using System.Collections.Generic;
using System.Linq;
using IEnumerableVsIQueryable.CoreApp.Models;

namespace IEnumerableVsIQueryable.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IEnumerable<Orders> ordersAsIEnumerable = OrdersFactory.CreateOrders().Where(x => x.OrderId == 1);
            foreach (var order in ordersAsIEnumerable)
            {
                Console.WriteLine($"OrderId: {order.OrderId}");
            }

            IQueryable<Orders> ordersAsIQuerable = OrdersFactory.CreateOrders().AsQueryable().Where(x => x.OrderId == 1);
            foreach (var order in ordersAsIQuerable)
            {
                Console.WriteLine($"OrderId: {order.OrderId}");
            }
        }
    }
}
