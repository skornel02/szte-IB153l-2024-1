using Backend.Attributes;
using Backend.Entities;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Backend.Pages.BakerPage
{
    [RoleAuthorize([Enums.UserRole.Admin, Enums.UserRole.Baker])]
    public class IndexModel : BasePageModel
    {
        private readonly BellaDbContext _context;

        public List<ProductEntity> Products { get; set; } = null!;

        public ProductIngredientsEntity ProductIngredientsEntity { get; set; } = default!;


        [BindProperty]
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

            if (id == null)
            {
                return RedirectToPage("./Index", new { ErrorMessage = "Product not found!" });
            }

            var productEntity = await _context.Products
                .Include(_ => _.Ingredients)
                .ThenInclude(_ => _.Ingredient)
                .FirstOrDefaultAsync(_ => _.Id == id);
            if (productEntity != null)
            {
                productEntity.Stock += NumberToMake;
                foreach (var item in productEntity.Ingredients)
                {
                    item.Ingredient.Stock -= item.Quantity * NumberToMake;
                }
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index", new { SuccessMessage = "Product(s) created successfully!" });
        }
    }
}
