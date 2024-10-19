using Microsoft.AspNetCore.Authorization;

namespace Backend.Pages;

[Authorize]
public class PrivacyModel : BasePageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

