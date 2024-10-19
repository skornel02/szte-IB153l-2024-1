using Backend.Entities;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Backend.Pages.Users;

public class IndexModel : PageModel
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
