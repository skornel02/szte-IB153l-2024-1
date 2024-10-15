namespace Backend.Entities;

public class IngredientEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public double Stock { get; set; }

    public double MaxStock { get; set; }

    public List<ProductIngredientsEntity> Products { get; set; } = null!;
}
