using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Backend.Entities;
using Backend.Persistence;
using Backend.Attributes;

namespace Backend.Pages.Ingredients;

[RoleAuthorize(Enums.UserRole.Admin, Enums.UserRole.Inventory)]
public class EditModel : BasePageModel
{
    private readonly Backend.Persistence.BellaDbContext _context;

    public EditModel(Backend.Persistence.BellaDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public IngredientEntity IngredientEntity { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ingrediententity =  await _context.Ingredients.FirstOrDefaultAsync(m => m.Id == id);
        if (ingrediententity == null)
        {
            return NotFound();
        }
        IngredientEntity = ingrediententity;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(IngredientEntity).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!IngredientEntityExists(IngredientEntity.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool IngredientEntityExists(Guid id)
    {
        return _context.Ingredients.Any(e => e.Id == id);
    }
}
