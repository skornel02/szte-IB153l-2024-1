using Backend.Attributes;
using Backend.Entities;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Pages.Products;

[RoleAuthorize(Enums.UserRole.Admin, Enums.UserRole.DigitalSales, Enums.UserRole.Chef)]
public class DetailsModel : BasePageModel
{
    private readonly BellaDbContext _context;

    public DetailsModel(BellaDbContext context)
    {
        _context = context;
    }

    public ProductEntity ProductEntity { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        // Load the product along with the Ingredients and Ingredient details
        ProductEntity = await _context.Products
            .Include(p => p.Ingredients)          // Include the Ingredients collection
            .ThenInclude(i => i.Ingredient)       // Include the Ingredient details for each entry
            .FirstOrDefaultAsync(m => m.Id == id);

        if (ProductEntity == null)
        {
            return NotFound();
        }

        return Page();
    }


}
