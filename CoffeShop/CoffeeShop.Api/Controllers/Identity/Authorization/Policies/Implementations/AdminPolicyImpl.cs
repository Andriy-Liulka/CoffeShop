using CoffeeShop.Domain.Constants;
using Microsoft.AspNetCore.Authorization;

namespace CoffeShop.Api.Controllers.Identity.Authorization.Policies.Implementations;

internal class AdminPolicyResolver : DefaultPolicyImpl
{
    internal override AuthorizationPolicyBuilder ResolvePolicy()
    {
        var policy = base.ResolvePolicy();
        policy.AddRequirements(
            new PermissionRequirement("MyAdminPolicy"),
            new PermissionRequirement("MyAdminPolicy")
            );
        policy.RequireRole(Roles.Admin);
        return policy;
    }
}