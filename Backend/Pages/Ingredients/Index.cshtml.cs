using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Backend.Entities;
using Backend.Persistence;
using Backend.Attributes;

namespace Backend.Pages.Ingredients;

[RoleAuthorize(Enums.UserRole.Admin, Enums.UserRole.Inventory)]
public class IndexModel : BasePageModel
{
    private readonly Backend.Persistence.BellaDbContext _context;

    public IndexModel(Backend.Persistence.BellaDbContext context)
    {
        _context = context;
    }

    public IList<IngredientEntity> IngredientEntitys { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync()
    {
        Guid? updated = null;
        Guid? failed = null;
        if (Guid.TryParse(Request.Query["updated"], out Guid parsedUpdatedGuid))
        {
            updated = parsedUpdatedGuid;
        } 
        else if (Guid.TryParse(Request.Query["failed"], out Guid parsedFailedGuid))
        {
            updated = parsedFailedGuid;
        }

        IngredientEntitys = await _context.Ingredients.ToListAsync();

        if (updated.HasValue)
        {
            SuccessMessage = $"Ingredient {IngredientEntitys.First(i => i.Id == updated).Name} was successfully updated.";
            return RedirectToPage("./Index", new { SuccessMessage });
        }
        else if (failed.HasValue)
        {
            ErrorMessage = $"Ingredient {IngredientEntitys.First(i => i.Id == updated).Name} cannot be updated.";
            return RedirectToPage("./Index", new { ErrorMessage });
        }

        return Page();
    }
}
