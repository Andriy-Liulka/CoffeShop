using System.Security.Claims;
using CoffeeShop.BusinessLogic.Common;
using CoffeeShop.BusinessLogic.Extensions;
using CoffeShop.Api.Authentication;
using Microsoft.AspNetCore.Http;

namespace CoffeeShop.BusinessLogic.Authentication;

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