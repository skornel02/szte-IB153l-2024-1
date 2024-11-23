using Backend.Entities;
using Backend.Persistence;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Backend.Pages;

public class LoginModel : BasePageModel
{
    private readonly BellaDbContext _context;

    [BindProperty]
    [Required(ErrorMessage = "E-Mail is required!")]
    [Display(Name = "Email Address")]
    [DataType(DataType.EmailAddress)]
    public string EmailAddress { get; set; }

    [BindProperty]
    [Length(3, 20), Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? RedirectTo { get; set; }

    public LoginModel(BellaDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(_ => _.EmailAddress == EmailAddress, cancellationToken);

        if (user is null)
        {
            ErrorMessage = "User does not exist with that E-mail address!";
            return Page();
        }

        var hasher = new PasswordHasher<UserEntity>();

        if (hasher.VerifyHashedPassword(user, user.PasswordHash, Password) == PasswordVerificationResult.Failed)
        {
            ErrorMessage = "Invalid password!";
            return Page();
        }

        user.LastSeen = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        var claims = new List<Claim>()
        {
            new(ClaimTypes.Email, EmailAddress),
            new(ClaimTypes.Role, user.Role.ToString()),
        };

        var principal = new ClaimsPrincipal([new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)]);

        var sessionId = HttpContext.Session.Id;

        if (!ShoppingCartContext.IsShoppingCartEmpty(sessionId))
        {
            var shoppingCart = ShoppingCartContext.GetShoppingCart(sessionId);
            ShoppingCartContext.SaveShoppingCart(EmailAddress, shoppingCart);
            ShoppingCartContext.ClearCart(sessionId);
        }

        await HttpContext.SignInAsync(principal);

        if (RedirectTo is not null)
        {
            return Redirect(RedirectTo);
        }

        var homePage = user.Role switch
        {
            Enums.UserRole.Admin => "/Users/Index",
            Enums.UserRole.DigitalSales => "/Orders/Pending/Index",
            //Enums.UserRole.PhysicalSales => "/PhyiscalSales",
            Enums.UserRole.Inventory => "/Ingreients/Index",
            Enums.UserRole.Baker => "/BakerPage/Index",
            Enums.UserRole.Chef => "/Products/Index",
            _ => "/Index",
        };

        return RedirectToPage(homePage, new { SuccessMessage = "You logged in successfully!" });
    }
}
