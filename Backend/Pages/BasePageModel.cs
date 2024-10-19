using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Backend.Pages;

public class BasePageModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string? ErrorMessage { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? SuccessMessage { get; set; }
}
