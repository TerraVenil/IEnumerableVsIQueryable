using System;
using System.Data.Entity;
using System.Linq;
using IEnumerableVsIQueryable.NETFrameworkApp.Extensions;

namespace IEnumerableVsIQueryable.NETFrameworkApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new NorthwindEntities { Configuration = { LazyLoadingEnabled = false, ProxyCreationEnabled = false }})
            {
                context.Database.Log = Console.Write;

                // 1.
                //var letters = context.LetterLanguageView.FilterByLetter("A");

                // 2.
                //var services = context.Services.ContainsByName("l");

                // 2.a
                //var services = context.Services.ContainsByName("M%");

                // 3.a
                //var services = context.Services.ContainsByNameWithLike("m%");

                // 4.
                //var services = context.Services.StartWith("m");

                // 5. INNER + OUTER
                //var orders = context.Orders.GetOrdersByCustomerId("VINET");
                //var orderDetails = context.EmployeeTerritories.Include(x => x.Territories).ToList();

                // 6
                //var resultWithIQueryable = context.Territories.GetRegionByTerritoryIdWithFirstBefore("02903");

                // 6.a
                //var resultWithIEnumerable = context.Territories.GetRegionByTerritoryIdWithFirstAfter("02903");
            }
        }
    }
}
