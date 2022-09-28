using CoffeeShop.Domain.Constants;
using Microsoft.AspNetCore.Authorization;

namespace CoffeShop.Api.Controllers.Identity.Authorization.Policies.Implementations;

internal class UserPolicyImpl : DefaultPolicyImpl
{
    internal override AuthorizationPolicyBuilder ResolvePolicy()
    {
        var policy = base.ResolvePolicy();
        policy.AddRequirements(
            new PermissionRequirement("MyUserPolicy"),
            new PermissionRequirement("MyUserPolicy")
            );
        policy.RequireRole(Roles.Customer,Roles.Admin);
        return policy;
    }
}