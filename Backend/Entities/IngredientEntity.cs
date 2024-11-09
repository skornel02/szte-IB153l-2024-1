using System.ComponentModel.DataAnnotations;

namespace Backend.Entities;

public class IngredientEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string ImageUrl { get; set; } = "/";

    [DisplayFormat(DataFormatString = "{0:N0}")]
    public double Stock { get; set; }

    [DisplayFormat(DataFormatString = "{0:N0}")]
    [Display(Name = "Maximum stock")]
    public double MaxStock { get; set; }

    public List<ProductIngredientsEntity> Products { get; set; } = new List<ProductIngredientsEntity>();
}
