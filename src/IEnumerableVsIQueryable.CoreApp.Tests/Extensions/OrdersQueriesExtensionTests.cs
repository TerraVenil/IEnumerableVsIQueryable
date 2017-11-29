using System;
using System.Collections.Generic;
using System.Linq;
using IEnumerableVsIQueryable.CoreApp.Extensions;
using IEnumerableVsIQueryable.CoreApp.Models;
using Xunit;

namespace IEnumerableVsIQueryable.CoreApp.Tests.Extensions
{
    public class OrdersQueriesExtensionTests
    {
        public static IEnumerable<object[]> GetOrders()
        {
            var orders = new List<Orders>
            {
                new Orders { OrderDate = new DateTime(2017, 7, 5), ShippedDate = new DateTime(2017, 8, 1) },
                new Orders { OrderDate = new DateTime(2017, 7, 7), ShippedDate = new DateTime(2018, 8, 1) },
                new Orders { OrderDate = new DateTime(2019, 7, 7), ShippedDate = new DateTime(2020, 8, 1) }
            };

            var expectedOrders = new List<Orders>
            {
                new Orders { OrderDate = new DateTime(2017, 7, 5), ShippedDate = new DateTime(2017, 8, 1) },
                new Orders { OrderDate = new DateTime(2017, 7, 7), ShippedDate = new DateTime(2018, 8, 1) }
            };

            yield return new object[] { orders, expectedOrders };
        }

        [Theory]
        [MemberData(nameof(GetOrders))]
        public void FilterOrdersTest(List<Orders> orders, List<Orders> expectedResult)
        {
            // Arrange
            var dataSource = new EnumerableQuery<Orders>(orders);

            // Act
            var result = dataSource.FilterOrders();

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}