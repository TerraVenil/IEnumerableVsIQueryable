using System.Linq;
using IEnumerableVsIQueryable.CoreApp.Models;

namespace IEnumerableVsIQueryable.CoreApp.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly OrdersContext _ordersContext;

        public OrdersRepository(OrdersContext ordersContext)
        {
            _ordersContext = ordersContext;
        }

        public IQueryable<Orders> Orders => _ordersContext.Orders.AsQueryable();
    }
}