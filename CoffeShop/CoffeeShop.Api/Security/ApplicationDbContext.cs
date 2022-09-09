using Microsoft.EntityFrameworkCore;

namespace CoffeShop.Api.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class ApplicationDbContext :IdentityDbContext<ApplicationSecurityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) {}
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}