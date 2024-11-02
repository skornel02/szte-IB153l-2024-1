using Backend.Attributes;
using Backend.Entities;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Backend.Pages.Webshop;

public class IndexModel : PageModel
{
    private readonly BellaDbContext _context;

    public List<ProductEntity> Products { get; set; } = null!;

    public int NumberToBuy { get; set; }

    public IndexModel(BellaDbContext context)
    {
        _context = context;
    }

    public async Task OnGetAsync()
    {
        Products = await _context.Products.ToListAsync();
    }
}
