using System.Collections.Generic;
using System.Linq;
using IEnumerableVsIQueryable.CoreApp.Controllers;
using IEnumerableVsIQueryable.CoreApp.Models;
using IEnumerableVsIQueryable.CoreApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace IEnumerableVsIQueryable.CoreApp.Tests.Controllers
{
    public class OrdersControllerTests
    {
        [Fact]
        public void GetOrdersAsQueryableTest()
        {
            // Arrange
            var ordersRepository = new Mock<IOrdersRepository>();
            ordersRepository.Setup(x => x.Orders).Returns(new EnumerableQuery<Orders>(new List<Orders>()));
            var ordersController = new OrdersQueryController(ordersRepository.Object);

            // Act
            var result = ordersController.GetOrdersAsQueryable();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}