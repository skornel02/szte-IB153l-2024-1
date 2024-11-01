using Backend.Attributes;
using Backend.Entities;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Backend.Pages.Products;

[RoleAuthorize(Enums.UserRole.Admin, Enums.UserRole.DigitalSales)]
public class EditModel : BasePageModel
{
    private readonly BellaDbContext _context;

    public List<IngredientEntity> Ingredients { get; set; } = null!;


    [BindProperty]
    public ProductEntity ProductEntity { get; set; } = default!;


    [BindProperty]
    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }

    [BindProperty]
    [Range(0, double.MaxValue)]
    [Required]
    public decimal Price { get; set; }

    public EditModel(BellaDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var productEntity = await _context.Products
            .Include(_ => _.Ingredients)
                .ThenInclude(_ => _.Ingredient)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (productEntity == null)
        {
            return NotFound();
        }
        
        ProductEntity = productEntity;
        Price = productEntity.Price;
        Description = productEntity.Description;

        Ingredients = await _context.Ingredients
            .OrderBy(_ => _.Name)
            .ToListAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Ingredients = await _context.Ingredients
            .OrderBy(_ => _.Name)
            .ToListAsync();

        // These fields shouldn't be validated because they can cause an invalid state on an otherwise valid input.
        ModelState.Remove($"{nameof(ProductEntity)}.{nameof(ProductEntity.OrderItems)}");
        ModelState.Remove($"{nameof(ProductEntity)}.{nameof(ProductEntity.Ingredients)}");
        ModelState.Remove($"{nameof(ProductEntity)}.{nameof(ProductEntity.Description)}");
        ModelState.Remove($"{nameof(ProductEntity)}.{nameof(ProductEntity.Price)}");
        if (!ModelState.IsValid)
        {
            return Page();
        }

        ProductEntity.Price = Price;
        ProductEntity.Description = Description ?? string.Empty;

        _context.Attach(ProductEntity).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductEntityExists(ProductEntity.Id))
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

    private bool ProductEntityExists(Guid id)
    {
        return _context.Products.Any(e => e.Id == id);
    }

    public async Task<IActionResult> OnPostAddIngredientAsync(Guid ingredientId, int quantity)
    {
            var ingredient = await _context.Ingredients.FindAsync(ingredientId);
        if (ingredient == null)
        {
            return RedirectToPage("/Products/Edit", new {
                id = ProductEntity.Id,
                ErrorMessage = "Ingredient not found"
            });
        }

        var productIngredient = new ProductIngredientsEntity
        {
            IngredientId = ingredientId,
            ProductId = ProductEntity.Id,
            Quantity = quantity
        };

        await _context.ProductIngredients.AddAsync(productIngredient);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Products/Edit", new {
            Id = ProductEntity.Id,
            SuccessMessage = "Ingredient added"
        });
    }

    public async Task<IActionResult> OnGetRemoveIngredientAsync(Guid productId, Guid ingredientId)
    {

        var productEntity = await _context.Products
            .Include(_ => _.Ingredients)
                .ThenInclude(_ => _.Ingredient)
            .FirstOrDefaultAsync(m => m.Id == productId);

        var productIngredient = productEntity.Ingredients.FirstOrDefault(_ => _.IngredientId == ingredientId);
        if (productIngredient == null)
        {
            return RedirectToPage("/Products/Edit", new {
                id = productId,
                ErrorMessage = "Ingredient not found"
            });
        }

        _context.ProductIngredients.Remove(productIngredient);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Products/Edit", new {
            Id = productId,
            SuccessMessage = "Ingredient removed"
        });
    }
}
