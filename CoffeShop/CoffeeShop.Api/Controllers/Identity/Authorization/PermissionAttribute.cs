using Microsoft.AspNetCore.Authorization;

namespace CoffeShop.Api.Controllers.Identity.Authorization;

public class PermissionAttribute : AuthorizeAttribute
{
    public PermissionAttribute(string requiredPermission)
        => RequiredPermission = requiredPermission;

    public string? RequiredPermission
    {
        get => Policy;
        set => Policy = value;
    }
}