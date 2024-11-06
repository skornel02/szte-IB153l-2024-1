using Backend.Attributes;
using Backend.Entities;
using Backend.Extensions;
using Backend.Models;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Backend.Pages.Webshop;

public class IndexModel : PageModel
{
    private readonly BellaDbContext _context;

    public List<ProductEntity> Products { get; set; } = null!;

    [BindProperty]
    public List<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;

    public IndexModel(BellaDbContext context)
    {
        _context = context;
    }

    public async Task OnGetAsync()
    {
        Products = await _context.Products.ToListAsync();
        ShoppingCartItems = ShoppingCartContext.GetShoppingCart(HttpContext.User.GetEmail());
    }

    public async Task<IActionResult> OnPostAsync()
    {
        ShoppingCartContext.SaveShoppingCart(HttpContext.User.GetEmail(), ShoppingCartItems);

        return RedirectToPage("./Index");
    }
}
