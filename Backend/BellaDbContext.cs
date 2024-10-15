using Backend.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend;

public class BellaDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<IngredientEntity> Ingredients { get; set; }
    public DbSet<ProductIngredientsEntity> ProductIngredients { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<OrderItemEntity> OrderItems { get; set; }

    public BellaDbContext(DbContextOptions options) : base(options)
    {
    }

    // seed
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var hasher = new PasswordHasher<UserEntity>();

        modelBuilder.Entity<UserEntity>()
            .HasData([
                new UserEntity() {
                    Id = Guid.Parse("4ab7c985-1a55-4866-90b3-fd9678d32203"),
                    EmailAddress = "admin@bellacroissant.fr",
                    PasswordHash = hasher.HashPassword(null!, "admin"),
                    Registered = DateTime.UtcNow,
                    Role = Enums.UserRole.Admin,
                }
                ]);

        modelBuilder.Entity<ProductIngredientsEntity>()
            .HasIndex(_ => new { _.IngredientId, _.ProductId })
            .IsUnique();
    }
}
