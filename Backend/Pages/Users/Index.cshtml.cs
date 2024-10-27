using Backend.Attributes;
using Backend.Entities;
using Backend.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Backend.Pages.Users;

[RoleAuthorize(Enums.UserRole.Admin)]
public class IndexModel : BasePageModel
{
    private readonly BellaDbContext _context;

    public IndexModel(BellaDbContext context)
    {
        _context = context;
    }

    public IList<UserEntity> UserEntity { get; set; } = default!;

    public async Task OnGetAsync()
    {
        UserEntity = await _context.Users.ToListAsync();
    }
}
