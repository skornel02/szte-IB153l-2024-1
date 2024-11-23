using Backend.Attributes;
using Backend.Entities;
using Backend.Enums;
using Backend.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Backend.Pages.Users;

[RoleAuthorize(Enums.UserRole.Admin)]
public class CreateModel : BasePageModel
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
    [PageRemote(
        ErrorMessage = "User already exists with that E-mail address!",
        AdditionalFields = "__RequestVerificationToken",
        PageName = "/Register",
        HttpMethod = "post",
        PageHandler = "CheckEmail")]
    [DataType(DataType.EmailAddress)]
    [Required]
    public string EmailAddress { get; set; } = null!;

    [BindProperty]
    public UserRole Role { get; set; }

    [BindProperty]
    [DataType(DataType.Password)]
    [Length(3, 20), Required]
    public string Password { get; set; } = string.Empty;

    [BindProperty]
    [DataType(DataType.Password)]
    [Required, Compare(nameof(Password))]
    public string PasswordAgain { get; set; } = string.Empty;

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        var hasher = new PasswordHasher<UserEntity>();

        var user = new UserEntity()
        {
            EmailAddress = EmailAddress,
            Role = Role,
            PasswordHash = hasher.HashPassword(null!, Password),
            Registered = DateTime.UtcNow,
            LastSeen = DateTime.MinValue,
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index", new { SuccessMessage = "User created successfully!"});
    }
}
