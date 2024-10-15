namespace Backend.Entities;

public class ProductIngredientsEntity
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public ProductEntity Product { get; set; } = null!;

    public Guid IngredientId { get; set; }

    public IngredientEntity Ingredient { get; set; } = null!;

    public double Quantity { get; set; }
}
