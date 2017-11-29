using System;
using System.Collections.Generic;
using System.Linq;
using IEnumerableVsIQueryable.CoreApp.Extensions;
using IEnumerableVsIQueryable.CoreApp.Models;
using IEnumerableVsIQueryable.CoreApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace IEnumerableVsIQueryable.CoreApp.Controllers
{
    [Route("api/[controller]")]
    public class OrdersQueryController : Controller
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersQueryController(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        [HttpGet]
        [Route("asQueryable")]
        public IActionResult GetOrdersAsQueryable()
        {
            // return NotFound
            // return BadRequest
            // return UnprocessableEntity

            IQueryable<Orders> orders = _ordersRepository.Orders;

            var result = orders
                .Where(x => x.OrderDate < new DateTime(1996, 7, 12) && x.OrderDate > new DateTime(1996, 7, 4))
                .OrderBy(x => x.ShippedDate)
                .GroupBy(x => x.ShipName);

            return Ok(result);
        }

        [HttpGet]
        [Route("asEnumerable")]
        public IActionResult GetOrdersAsEnumerable()
        {
            IEnumerable<Orders> orders = _ordersRepository.Orders;

            var result = orders
                .Where(x => x.OrderDate < new DateTime(1996, 7, 12) && x.OrderDate > new DateTime(1996, 7, 4))
                .OrderBy(x => x.ShippedDate)
                .GroupBy(x => x.ShipName);

            return Ok(result);
        }
    }
}
