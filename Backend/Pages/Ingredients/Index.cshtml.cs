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
    public class IndexModel : BasePageModel
    {
        private readonly Backend.Persistence.BellaDbContext _context;

        public IndexModel(Backend.Persistence.BellaDbContext context)
        {
            _context = context;
        }

        public IList<IngredientEntity> IngredientEntity { get;set; } = default!;

        public async Task OnGetAsync()
        {
            IngredientEntity = await _context.Ingredients.ToListAsync();
        }
    }
}
