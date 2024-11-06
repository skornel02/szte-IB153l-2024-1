using Backend.Enums;
using System.Security.Claims;

namespace Backend.Extensions;

public static class UserExtensions
{
    public static bool HasRole(this ClaimsPrincipal user, params UserRole[] roles)
    {
        return roles.Any(_ => user.IsInRole(_.ToString()));
    }

    public static bool IsLoggedIn(this ClaimsPrincipal user)
    {
        return user.Identity?.IsAuthenticated ?? false;
    }

    public static string? GetEmail(this ClaimsPrincipal? user)
    {
        return user?.FindFirst(ClaimTypes.Email)?.Value;
    }
}
