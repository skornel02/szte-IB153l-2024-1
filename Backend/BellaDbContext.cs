using Microsoft.EntityFrameworkCore;

namespace Backend;

public class BellaDbContext : DbContext
{
    public BellaDbContext(DbContextOptions options) : base(options)
    {
    }
}
