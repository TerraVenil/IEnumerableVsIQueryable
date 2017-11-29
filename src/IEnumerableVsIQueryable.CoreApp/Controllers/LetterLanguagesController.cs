using System.Linq;
using IEnumerableVsIQueryable.CoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace IEnumerableVsIQueryable.CoreApp.Controllers
{
    [Route("api/[controller]")]
    public class LetterLanguagesController : Controller
    {
        private readonly OrdersContext _ordersContext;

        public LetterLanguagesController(OrdersContext ordersContext)
        {
            _ordersContext = ordersContext;
        }

        [HttpGet]
        [Route("letters")]
        public IActionResult GetLetters()
        {
            var result = _ordersContext.LetterLanguageViews.ToList();

            return Ok(result);
        }
    }
}