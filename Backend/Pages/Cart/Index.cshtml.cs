using Backend.Entities;
using Backend.Enums;
using Backend.Extensions;
using Backend.Models;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Pages.Cart;

public class IndexModel : BasePageModel
{
    private readonly BellaDbContext _context;

    public List<ProductEntity> Products { get; set; } = [];

    [BindProperty]
    public List<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;

    public decimal TotalPrice { get; set; }

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
    }
    public async Task<IActionResult> OnPostPlaceOrderAsync()
    {
        var email = User.GetEmail();
        var userEmail = User.GetEmailOrSessionId(HttpContext);

        if (email is null)
        {
            return RedirectToPage("/Login", new { ErrorMessage = "Please log in or register before placing your order!", RedirectTo = "/Cart/Index" });
        }

        var user = await _context.Users.FirstOrDefaultAsync(u => u.EmailAddress == userEmail);

        if (user == null || !ShoppingCartItems.Any())
        {
            return RedirectToPage("/Cart/Index");
        }

        var productIds = ShoppingCartItems.Select(item => item.ProductId).ToList();
        var products = await _context.Products
                                     .Where(p => productIds.Contains(p.Id))
                                     .ToListAsync();

        var validProductIds = products.Select(p => p.Id).ToHashSet();
        ShoppingCartItems = ShoppingCartItems
                            .Where(item => validProductIds.Contains(item.ProductId))
                            .ToList();

        if (!ShoppingCartItems.Any())
        {
            ShoppingCartContext.ClearCart(userEmail);
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

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        ShoppingCartContext.ClearCart(userEmail);

        return RedirectToPage("/Orders/MyOrders/Index", new { SuccessMessage = "Your order has been placed." });
    }

    public async Task<IActionResult> OnPostRemoveItemAsync(Guid productId)
    {
        var userEmail = User.GetEmailOrSessionId(HttpContext);

        var shoppingCart = ShoppingCartContext.GetShoppingCart(userEmail);
        var itemToRemove = shoppingCart.FirstOrDefault(item => item.ProductId == productId);

        if (itemToRemove != null)
        {
            shoppingCart.Remove(itemToRemove);
            ShoppingCartContext.SaveShoppingCart(userEmail, shoppingCart);

            var products = await _context.Products
                                         .Where(p => shoppingCart.Select(i => i.ProductId).Contains(p.Id))
                                         .ToListAsync();
            TotalPrice = shoppingCart.Sum(item => item.Quantity * products.First(p => p.Id == item.ProductId).Price);
        }

        return RedirectToPage();
    }
    public IActionResult OnPostUpdateQuantity(Guid productId, int quantity)
    {
        var userEmail = User.GetEmailOrSessionId(HttpContext);

        var shoppingCart = ShoppingCartContext.GetShoppingCart(userEmail);
        var itemToUpdate = shoppingCart.FirstOrDefault(item => item.ProductId == productId);

        if (itemToUpdate != null)
        {
            var updatedItem = new ShoppingCartItem(productId, quantity);

            shoppingCart.Remove(itemToUpdate);
            if (quantity > 0)
            {
                shoppingCart.Add(updatedItem);
            }

            ShoppingCartContext.SaveShoppingCart(userEmail, shoppingCart);
        }

        return RedirectToPage();
    }


}
