using CoffeShop.Api.Controllers.Identity.Authorization.Policies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace CoffeShop.Api.Controllers.Identity.Authorization;

public class PermissionPolicyProvider : IAuthorizationPolicyProvider
{
    private readonly IPolicyResolver _policyResolver;
    public PermissionPolicyProvider(IPolicyResolver policyResolver)
    {
        _policyResolver = policyResolver;
    }

    public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        => Task.FromResult(_policyResolver.PolicyImlStorage[policyName].Invoke() ?? null);
    
    public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        => Task.FromResult(_policyResolver.PolicyImlStorage[PoliciesNames.DefaultPolicy].Invoke());

    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
        => Task.FromResult<AuthorizationPolicy?>(null);
}