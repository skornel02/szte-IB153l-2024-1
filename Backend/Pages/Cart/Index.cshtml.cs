using Backend.Attributes;
using Backend.Entities;
using Backend.Extensions;
using Backend.Models;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace Backend.Pages.Cart;

public class IndexModel : PageModel
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
                            .GetShoppingCart(HttpContext.User.GetEmailOrVisitor())
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
}
