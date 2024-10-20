using Backend.Entities;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Backend.Pages.Products;

public class IndexModel : PageModel
{
    private readonly BellaDbContext _context;

    public List<ProductEntity> Products { get; set; } = null!;

    [BindProperty]
    public string Name { get; set; } = null!;

    [BindProperty]
    public string Description { get; set; } = null!;

    [BindProperty]
    public decimal Price { get; set; }

    public IndexModel(BellaDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        Products = _context.Products.ToList();
    }

    public IActionResult OnPost()
    {
        var newProduct = new ProductEntity()
        {
            Name = Name,
            Description = Description,
            Price = Price,
            ImageUrl = "/images/bread-normal.png",
            Reserved = 0,
            Stock = 0,
        };

        _context.Products.Add(newProduct);
        _context.SaveChanges();

        return RedirectToPage("./Index");
    }
}
