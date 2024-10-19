using Backend.Entities;
using Backend.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Backend.Pages.Users;

public class CreateModel : PageModel
{
    private readonly BellaDbContext _context;

    public CreateModel(BellaDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public UserEntity UserEntity { get; set; } = default!;

    [BindProperty]
    [DataType(DataType.Password)]
    [Required]
    public string Password { get; set; } = string.Empty;

    [BindProperty]
    [DataType(DataType.Password)]
    [Required, Compare(nameof(Password))]
    public string PasswordAgain { get; set; } = string.Empty;

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        var hasher = new PasswordHasher<UserEntity>();
        UserEntity.PasswordHash = hasher.HashPassword(UserEntity, Password);
        UserEntity.Registered = DateTime.UtcNow;
        UserEntity.LastSeen = DateTime.MinValue;

        _context.Users.Add(UserEntity);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
