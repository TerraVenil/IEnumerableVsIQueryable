using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using IEnumerableVsIQueryable.NETFrameworkApp.Extensions;
using Xunit;

namespace IEnumerableVsIQueryable.NETFrameworkApp.Tests
{
    public class IncludeWithJoinTests
    {
        /// SELECT 
        ///    *
        ///    FROM  [dbo].[Orders] AS [Extent1]
        ///    LEFT OUTER JOIN [dbo].[Customers] AS [Extent2] ON [Extent1].[CustomerID] = [Extent2].[CustomerID]
        ///    WHERE N'VINET' = [Extent1].[CustomerID]
        [Fact]
        public void GetOrdersByCustomerId()
        {
            // Arrange
            var orders = new EnumerableQuery<Orders>(
                             new List<Orders>
                             {
                                 new Orders
                                 {
                                     OrderID = 10248,
                                     CustomerID = "VINET",
                                     Customers = new Customers { CustomerID = "VINET" }
                                 },
                                 new Orders
                                 {
                                     OrderID = 10249,
                                     CustomerID = null,
                                     Customers = null
                                 }
                             });

            // Act
            var result = orders.GetOrdersByCustomerId("VINET");

            // Assert
            result.ShouldBeEquivalentTo(new List<Orders> { new Orders { OrderID = 10248, CustomerID = "VINET", Customers = new Customers { CustomerID = "VINET" } } });
        }
    }
}