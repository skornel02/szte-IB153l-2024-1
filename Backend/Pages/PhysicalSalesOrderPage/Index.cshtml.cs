using Backend.Attributes;
using Backend.Entities;
using Backend.Extensions;
using Backend.Models;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Backend.Pages.PhysicalSalesOrderPage;

[RoleAuthorize(Enums.UserRole.PhysicalSales, Enums.UserRole.Admin)]
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
        Products = await _context.Products.ToListAsync();

        foreach (var item in ShoppingCartItems)
        {
            var product = Products.FirstOrDefault(p => p.Id == item.ProductId);

            if (product == null || item.Quantity < 0)
            {
                ModelState.AddModelError("", "Hibás mennyiség.");
                return Page();
            }

            if (product.Stock < item.Quantity)
            {
                ModelState.AddModelError("", $"Nincs elegendõ készlet a(z) {product?.Name ?? "termékhez"}.");
                return Page();
            }

            product.Stock -= item.Quantity;
        }

        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
}
