using Backend.Attributes;
using Backend.Entities;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Pages.Products;

[RoleAuthorize(Enums.UserRole.Admin, Enums.UserRole.DigitalSales, Enums.UserRole.Chef)]
public class DeleteModel : BasePageModel
{
    private readonly BellaDbContext _context;

    public DeleteModel(BellaDbContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var productEntity = await _context.Products.FindAsync(id);
        if (productEntity != null)
        {
            ProductEntity = productEntity;
            _context.Products.Remove(ProductEntity);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
