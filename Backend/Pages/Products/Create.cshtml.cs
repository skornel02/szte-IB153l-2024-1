using Backend.Attributes;
using Backend.Entities;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Backend.Pages.Products;

[RoleAuthorize(Enums.UserRole.Admin, Enums.UserRole.DigitalSales, Enums.UserRole.Chef)]
public class CreateModel : BasePageModel
{
    private readonly BellaDbContext _context;

    public CreateModel(BellaDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public ProductEntity ProductEntity { get; set; } = default!;

    [BindProperty]
    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }

    [BindProperty]
    [Range(0, double.MaxValue)]
    [Required]
    public decimal Price { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        ProductEntity.Price = Price;

        ProductEntity.Reserved = 0;
        ProductEntity.Stock = 0;
        ProductEntity.Description = Description ?? string.Empty;

        _context.Products.Add(ProductEntity);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
