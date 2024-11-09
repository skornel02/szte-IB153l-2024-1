using Backend.Attributes;
using Backend.Entities;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Pages.Products;

[RoleAuthorize(Enums.UserRole.Admin, Enums.UserRole.DigitalSales)]
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

        var productEntity = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
        if (productEntity == null)
        {
            return NotFound();
        }
        else
        {
            ProductEntity = productEntity;
        }
        return Page();
    }
}
