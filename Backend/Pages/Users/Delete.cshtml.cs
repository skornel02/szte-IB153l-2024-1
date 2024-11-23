using Backend.Attributes;
using Backend.Entities;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Pages.Users;

[RoleAuthorize(Enums.UserRole.Admin)]
public class DeleteModel : BasePageModel
{
    private readonly BellaDbContext _context;

    public DeleteModel(BellaDbContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var userentity = await _context.Users.FindAsync(id);
        if (userentity != null)
        {
            UserEntity = userentity;
            _context.Users.Remove(UserEntity);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index", new { SuccessMessage = "User removed successfully!"});
    }
}
