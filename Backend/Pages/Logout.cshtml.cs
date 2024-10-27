using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Pages;

public class LogoutModel : BasePageModel
{
    public async Task<IActionResult> OnGetAsync()
    {
        await HttpContext.SignOutAsync();

        return RedirectToPage("/Login", new
        {
            ErrorMessage,
            SuccessMessage = "You logged out successfully!"
        });
    }
}
