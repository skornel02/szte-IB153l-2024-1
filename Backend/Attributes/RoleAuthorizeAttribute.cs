using Backend.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Attributes;

public class RoleAuthorizeAttribute : AuthorizeAttribute
{
    public RoleAuthorizeAttribute(params UserRole[] role) : base()
    {
        Roles = string.Join(",", role);
    }
}
