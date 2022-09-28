using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace CoffeShop.Api.Controllers.Identity.Authorization.Policies.Implementations;

internal class DefaultPolicyImpl
{
    internal AuthorizationPolicyBuilder policy = new();

    internal virtual AuthorizationPolicyBuilder ResolvePolicy()
    {
        policy.RequireAuthenticatedUser();
        policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
        return policy;
    }
    
}