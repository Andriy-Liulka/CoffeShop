using CoffeeShop.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations.IdentityConfigurations;

public class RoleConfiguration : IEntityConfiguration<Role>
{
    public EntityTypeBuilder<Role> Configure(EntityTypeBuilder<Role> builder)
    {
        throw new Exception();
    }
}