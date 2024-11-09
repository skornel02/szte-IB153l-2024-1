using Backend.Attributes;
using Backend.Entities;
using Backend.Persistence;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Endpoints;

public static class IngredientsEndpoints
{
    public static void MapIngredientsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/ingredients", 
        [RoleAuthorize(Enums.UserRole.Admin, Enums.UserRole.Inventory)] async (
            [FromServices] BellaDbContext context, 
            [FromBody] IngredientEntity modIngredient
        ) =>
        {
            var ingredient = await context.Ingredients.FirstOrDefaultAsync(i => i.Id == modIngredient.Id);
            if (ingredient is null)
            {
                Results.NotFound();
                return;
            }

            ingredient.Stock = modIngredient.Stock;

            await context.SaveChangesAsync();
            Results.Ok();
        });
    }
}
