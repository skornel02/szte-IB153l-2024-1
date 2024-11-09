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

    
}
