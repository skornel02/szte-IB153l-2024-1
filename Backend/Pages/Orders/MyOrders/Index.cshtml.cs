using Backend.Entities;
using Backend.Extensions;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Backend.Pages.Orders.MyOrders
{
    public class IndexModel : PageModel
    {
        private readonly BellaDbContext _context;

        public List<OrderEntity> Orders { get; set; } = new List<OrderEntity>();

        public IndexModel(BellaDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            var userEmail = User.GetEmail();

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.EmailAddress == userEmail);

            if (user != null)
            {
                Orders = await _context.Orders
                    .Where(order => order.CustomerId == user.Id)
                    .Include(order => order.OrderItems)
                    .ThenInclude(item => item.Product)
                    .ToListAsync();
            }

        }
    }
}
