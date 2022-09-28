using CoffeShop.Api.Controllers.Identity.Authorization.Policies.Implementations;
using Microsoft.AspNetCore.Authorization;

namespace CoffeShop.Api.Controllers.Identity.Authorization.Policies;

internal sealed class PolicyResolver : IPolicyResolver
{
    public IReadOnlyDictionary<string, Func<AuthorizationPolicy>> PolicyImlStorage { get;}

    public PolicyResolver()
    {
        PolicyImlStorage = new Dictionary<string, Func<AuthorizationPolicy>>()
        {
            [PoliciesNames.DefaultPolicy] = () => new DefaultPolicyImpl().ResolvePolicy().Build(),
            [PoliciesNames.UserPolicy] = () => new UserPolicyImpl().ResolvePolicy().Build(),
            [PoliciesNames.AdminPolicy] = () => new AdminPolicyResolver().ResolvePolicy().Build(),
        };
    }
}