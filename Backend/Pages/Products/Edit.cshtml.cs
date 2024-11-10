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

    public List<IngredientEntity> Ingredients { get; set; } = default!;


    [BindProperty]
    public ProductEntity ProductEntity { get; set; } = default!;


    [BindProperty]
    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }

    [BindProperty]
    [Range(0, double.MaxValue)]
    [Required]
    public decimal Price { get; set; }

    [BindProperty]
    public Dictionary<Guid, int> Quantities { get; set; } = new(); 

    [BindProperty]
    public Dictionary<Guid, string> IngredientNames { get; set; } = new(); 


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
            .Include(p => p.Ingredients) 
            .ThenInclude(pi => pi.Ingredient) 
            .FirstOrDefaultAsync(m => m.Id == id);

        if (productEntity == null)
        {
            return NotFound();
        }

        
        ProductEntity = productEntity;
        ProductEntity.Ingredients ??= new List<ProductIngredientsEntity>();
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

    public async Task<IActionResult> OnPostEditIngredientsAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Retrieve the product entity along with its ingredients
        var productEntity = await _context.Products
            .Include(p => p.Ingredients)
            .ThenInclude(pi => pi.Ingredient)
            .FirstOrDefaultAsync(p => p.Id == ProductEntity.Id);

        if (productEntity == null)
        {
            return NotFound();
        }

        // Update ingredient quantities based on the Quantities dictionary from the form
        foreach (var productIngredient in productEntity.Ingredients)
        {
            if (Quantities.TryGetValue(productIngredient.IngredientId, out var newQuantity))
            {
                productIngredient.Quantity = newQuantity;
            }
        }

        // Attach and save changes
        _context.Attach(productEntity).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return RedirectToPage("/Products/Edit", new { id = ProductEntity.Id, SuccessMessage = "Ingredients updated successfully" });
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
            return RedirectToPage("/Products/Edit", new
            {
                id = productId,
                ErrorMessage = "Ingredient not found"
            });
        }

        _context.ProductIngredients.Remove(productIngredient);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Products/Edit", new
        {
            Id = productId,
            SuccessMessage = "Ingredient removed"
        });
    }
}

