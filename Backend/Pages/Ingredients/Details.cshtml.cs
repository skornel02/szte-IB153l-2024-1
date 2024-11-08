using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Backend.Entities;
using Backend.Persistence;

namespace Backend.Pages.Ingredients
{
    public class DetailsModel : BasePageModel
    {
        private readonly Backend.Persistence.BellaDbContext _context;

        public DetailsModel(Backend.Persistence.BellaDbContext context)
        {
            _context = context;
        }

        public IngredientEntity IngredientEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingrediententity = await _context.Ingredients.FirstOrDefaultAsync(m => m.Id == id);
            if (ingrediententity == null)
            {
                return NotFound();
            }
            else
            {
                IngredientEntity = ingrediententity;
            }
            return Page();
        }
    }
}
