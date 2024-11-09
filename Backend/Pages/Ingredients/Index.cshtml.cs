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

    public IList<IngredientEntity> IngredientEntities { get; set; } = default!;

    [BindProperty(SupportsGet = true)]
    public Guid? Updated { get; set; }

    [BindProperty(SupportsGet = true)]
    public Guid? Failed { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        IngredientEntities = await _context.Ingredients.ToListAsync();

        if (Updated.HasValue)
        {
            SuccessMessage = $"Ingredient {IngredientEntities.First(i => i.Id == Updated).Name} was successfully updated.";
            return RedirectToPage("./Index", new { SuccessMessage });
        }
        else if (Failed.HasValue)
        {
            ErrorMessage = $"Ingredient {IngredientEntities.First(i => i.Id == Failed).Name} cannot be updated.";
            return RedirectToPage("./Index", new { ErrorMessage });
        }

        return Page();
    }
}
