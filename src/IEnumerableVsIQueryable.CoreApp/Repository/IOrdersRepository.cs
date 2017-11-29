using System.Linq;
using IEnumerableVsIQueryable.CoreApp.Models;

namespace IEnumerableVsIQueryable.CoreApp.Repository
{
    public interface IOrdersRepository
    {
        IQueryable<Orders> Orders { get; }
    }
}