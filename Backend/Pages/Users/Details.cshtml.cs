using Backend.Attributes;
using Backend.Entities;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Pages.Users;

[RoleAuthorize(Enums.UserRole.Admin)]
public class DetailsModel : BasePageModel
{
    private readonly BellaDbContext _context;

    public DetailsModel(BellaDbContext context)
    {
        _context = context;
    }

    public UserEntity UserEntity { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var userentity = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
        if (userentity == null)
        {
            return NotFound();
        }
        else
        {
            UserEntity = userentity;
        }
        return Page();
    }
}
