using System.ComponentModel.DataAnnotations;

namespace Backend.Entities;

public class IngredientEntity
{
    public Guid Id { get; set; }

    [Display(Name = "Megnevezés")]
    public string Name { get; set; } = null!;

    [Display(Name = "Kép")]
    public string ImageUrl { get; set; } = "/";

    [DisplayFormat(DataFormatString = "{0:N0}")]
    [Display(Name = "Raktáron")]
    public double Stock { get; set; }

    [DisplayFormat(DataFormatString = "{0:N0}")]
    [Display(Name = "Maximum raktáron")]
    public double MaxStock { get; set; }

    public List<ProductIngredientsEntity> Products { get; set; } = null!;
}
