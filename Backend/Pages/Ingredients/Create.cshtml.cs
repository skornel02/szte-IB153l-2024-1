using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Backend.Entities;
using Backend.Persistence;

namespace Backend.Pages.Ingredients
{
    public class CreateModel : BasePageModel
    {
        private readonly Backend.Persistence.BellaDbContext _context;

        public CreateModel(Backend.Persistence.BellaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public IngredientEntity IngredientEntity { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ingredients.Add(IngredientEntity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
