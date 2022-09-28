using Microsoft.AspNetCore.Authorization;

namespace CoffeShop.Api.Controllers.Identity.Authorization.Policies;

public interface IPolicyResolver
{
    IReadOnlyDictionary<string, Func<AuthorizationPolicy>> PolicyImlStorage { get;}
}