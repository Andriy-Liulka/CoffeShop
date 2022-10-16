using System.Security.Claims;

namespace CoffeeShop.BusinessLogic.Extensions;

public static class ClaimsPrincipalExtension
{
    public static string GetUserIdentityUnit(this ClaimsPrincipal claimsPrincipal, string claimType)
        => claimsPrincipal.Identities.First().Claims.First(x => x.Type.Equals(claimType)).Value;
}