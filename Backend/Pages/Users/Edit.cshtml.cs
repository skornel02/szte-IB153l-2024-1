using Backend.Entities;
using Backend.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Backend.Pages.Users;

public class EditModel : PageModel
{
    private readonly BellaDbContext _context;

    public EditModel(BellaDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public UserEntity UserEntity { get; set; } = default!;

    [BindProperty]
    [DataType(DataType.Password)]
    [Required]
    public string Password { get; set; } = string.Empty;

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
        UserEntity = userentity;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var hasher = new PasswordHasher<UserEntity>();
        UserEntity.PasswordHash = hasher.HashPassword(UserEntity, Password);

        _context.Attach(UserEntity).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserEntityExists(UserEntity.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool UserEntityExists(Guid id)
    {
        return _context.Users.Any(e => e.Id == id);
    }
}
