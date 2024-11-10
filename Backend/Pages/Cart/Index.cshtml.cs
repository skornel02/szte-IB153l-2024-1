using Backend.Entities;
using Backend.Enums;
using Backend.Extensions;
using Backend.Models;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;

namespace Backend.Pages.Cart;

public class IndexModel : PageModel
{
    private readonly BellaDbContext _context;

    public List<ProductEntity> Products { get; set; } = [];

    [BindProperty]
    public List<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;

    public decimal TotalPrice { get; set; }
    public decimal price = 0;

    public IndexModel(BellaDbContext context)
    {
        _context = context;
    }

    public async Task OnGetAsync()
    {
        ShoppingCartItems = ShoppingCartContext
                            .GetShoppingCart(HttpContext.User.GetEmailOrSessionId(HttpContext))
                            .Where(item => item.Quantity != 0)
                            .ToList();

        if (ShoppingCartItems.IsNullOrEmpty())
        {
            return;
        }

        foreach (var item in ShoppingCartItems)
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == item.ProductId);
            if (product is not null)
            {
                Products.Add(product);
                TotalPrice += item.Quantity * product.Price;
            }
        }
        price = TotalPrice;
    }
    public async Task<IActionResult> OnPostPlaceOrderAsync()
    {

        var userEmail = User.GetEmailOrSessionId(HttpContext);
        var user = await _context.Users.FirstOrDefaultAsync(u => u.EmailAddress == userEmail);

        if (user == null || !ShoppingCartItems.Any())
        {
            return RedirectToPage("/Cart/Index");
        }

        var productIds = ShoppingCartItems.Select(item => item.ProductId).ToList();
        var products = await _context.Products
                                     .Where(p => productIds.Contains(p.Id))
                                     .ToListAsync();

        if (products.Count != ShoppingCartItems.Count)
        {
            return RedirectToPage("/Cart/Index");
        }

        TotalPrice = ShoppingCartItems.Sum(item => item.Quantity * products.First(p => p.Id == item.ProductId).Price);

        var id = Guid.NewGuid();
        var order = new OrderEntity
        {
            Id = id,
            CustomerId = user.Id,
            OrderPlaced = DateTime.UtcNow,
            Status = OrderStatus.OrderPlaced,
            TotalPrice = TotalPrice,
            OrderItems = ShoppingCartItems.Select(item => new OrderItemEntity
            {
                Id = Guid.NewGuid(),
                OrderId = id, 
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = products.First(p => p.Id == item.ProductId).Price
            }).ToList()
        };

        foreach (var orderItem in order.OrderItems)
        {
            orderItem.OrderId = order.Id;
        }

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        ShoppingCartContext.ClearCart(userEmail);

        return RedirectToPage("/Orders/MyOrders/Index");
    }

}
