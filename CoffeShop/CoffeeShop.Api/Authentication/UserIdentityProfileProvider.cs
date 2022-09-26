using System.Security.Claims;
using CoffeShop.Api.Common;
using CoffeShop.Api.Configurations.Extensions;

namespace CoffeShop.Api.Authentication;

public class UserIdentityProfileProvider : IUserIdentityProfileProvider
{
    private readonly IHttpContextAccessor _httpContext;
    public UserIdentityProfileProvider(IHttpContextAccessor httpContext)
    {
        _httpContext = httpContext;
    }

    public string UserName => _httpContext.HttpContext?.User.GetUserIdentityUnit(ClaimTypes.Name) 
                              ?? Translation.DefaultName;
    public string Email => _httpContext.HttpContext?.User.GetUserIdentityUnit(ClaimTypes.Email) 
                           ?? Translation.DefaultEmail;
    public string RoleName => _httpContext.HttpContext?.User.GetUserIdentityUnit(ClaimTypes.Role)
                              ?? Translation.DefaultRole;
}