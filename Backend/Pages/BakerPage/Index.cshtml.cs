using Backend.Attributes;
using Backend.Entities;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Backend.Pages.BakerPage;

[RoleAuthorize(Enums.UserRole.Admin, Enums.UserRole.Baker)]
public class IndexModel : BasePageModel
{
    private readonly BellaDbContext _context;

    public List<ProductEntity> Products { get; set; } = null!;

    [BindProperty]
    [Range(1, int.MaxValue, ErrorMessage = "The number of products must be between {1} and {2}.")]
    public int NumberToMake { get; set; }

    public IndexModel(BellaDbContext context)
    {
        _context = context;
    }

    public async Task OnGetAsync()
    {
        Products = await _context.Products
            .Include(_ => _.Ingredients)
                .ThenInclude(_ => _.Ingredient)
            .ToListAsync();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        var productEntity = await _context.Products
            .Include(_ => _.Ingredients)
            .ThenInclude(_ => _.Ingredient)
            .FirstOrDefaultAsync(_ => _.Id == id);

        if (productEntity is null)
        {
            return RedirectToPage("./Index", new { ErrorMessage = "Product not found!" });
        }

        productEntity.Stock += NumberToMake;
        var notEnoughIngredients = new List<string>();

        foreach (var item in productEntity.Ingredients)
        {
            item.Ingredient.Stock -= item.Quantity * NumberToMake;
            if (item.Ingredient.Stock < 0)
            {
                notEnoughIngredients.Add(item.Ingredient.Name);
            }
        }

        if (notEnoughIngredients.Count != 0)
        {
            return RedirectToPage("./Index", new { ErrorMessage = $"Not enough from {string.Join(", ", notEnoughIngredients)}" });
        }

        await _context.SaveChangesAsync();

        return RedirectToPage("./Index", new { SuccessMessage = "Product(s) created successfully!" });
    }
}
