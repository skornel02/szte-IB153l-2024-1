using Backend.Entities;
using Backend.Extensions;
using Backend.Models;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Backend.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private readonly BellaDbContext _context;

    public List<ProductEntity> Products { get; set; } = null!;

    [BindProperty]
    public List<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;

    public IndexModel(ILogger<IndexModel> logger, BellaDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task OnGetAsync()
    {
        Products = await _context.Products.ToListAsync();
        ShoppingCartItems = ShoppingCartContext.GetShoppingCart(HttpContext.User.GetEmailOrSessionId(HttpContext));
    }

    public async Task<IActionResult> OnPostAsync()
    {
        ShoppingCartContext.SaveShoppingCart(HttpContext.User.GetEmailOrSessionId(HttpContext), ShoppingCartItems);

        return RedirectToPage("./Index");
    }
}

