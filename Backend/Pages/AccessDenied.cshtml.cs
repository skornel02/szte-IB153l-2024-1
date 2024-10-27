using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Pages;

public class AccessDeniedModel : BasePageModel
{
    [BindProperty]
    public string? RedirectTo { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await HttpContext.SignOutAsync();

        return RedirectToPage("/Login", new { RedirectTo, SuccessMessage = "You logged out succesfully!" });
    }
}
