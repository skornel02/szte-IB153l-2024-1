namespace Backend.Entities;

public class ProductEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public string ImageUrl { get; set; } = null!;

    public int Stock { get; set; }

    public int Reserved { get; set; }

    public List<OrderItemEntity> OrderItems { get; set; } = null!;

    public List<ProductIngredientsEntity> Ingredients { get; set; } = null!;
}
