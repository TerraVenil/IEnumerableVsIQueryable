using Microsoft.EntityFrameworkCore;

namespace IEnumerableVsIQueryable.CoreApp.Models
{
    public partial class OrdersContext
    {
        public OrdersContext(DbContextOptions<OrdersContext> options)
            : base(options)
        { }

        public virtual DbSet<LetterLanguageView> LetterLanguageViews { get; set; }
    }
}