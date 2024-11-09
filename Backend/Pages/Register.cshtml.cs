using Backend.Entities;
using Backend.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Backend.Pages;

public class RegisterModel : BasePageModel
{
    private readonly BellaDbContext _context;

    [BindProperty]
    [Required(ErrorMessage = "E-Mail is required!")]
    [Display(Name = "Email Address")]
    [DataType(DataType.EmailAddress)]
    [PageRemote(
        ErrorMessage = "User already exists with that E-mail address!",
        AdditionalFields = "__RequestVerificationToken",
        HttpMethod = "post",
        PageHandler = "CheckEmail")]
    public string EmailAddress { get; set; }

    [BindProperty]
    [Length(3, 20), Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [BindProperty]
    [Compare(nameof(Password), ErrorMessage = "The two passwords must match!")]
    [DataType(DataType.Password)]
    [Display(Name = "Password Again")]
    public string PasswordAgain { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? RedirectTo { get; set; }

    public RegisterModel(BellaDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
    {
        var existingUser = await _context.Users
            .FirstOrDefaultAsync(_ => _.EmailAddress == EmailAddress, cancellationToken);

        if (existingUser is not null)
        {
            ErrorMessage = "User already exist with that E-mail address!";
            return Page();
        }

        var hasher = new PasswordHasher<UserEntity>();

        var user = new UserEntity
        {
            EmailAddress = EmailAddress,
            PasswordHash = hasher.HashPassword(null!, Password),
            Role = Enums.UserRole.WebshopUser,
            Registered = DateTime.UtcNow,
        };

        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return RedirectToPage("/Login", new { SuccessMessage = "You registered succesfully! Please log in now...", RedirectTo });
    }

    public async Task<JsonResult> OnPostCheckEmailAsync(CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(_ => _.EmailAddress == EmailAddress, cancellationToken);

        return new JsonResult(user is null);
    }
}
