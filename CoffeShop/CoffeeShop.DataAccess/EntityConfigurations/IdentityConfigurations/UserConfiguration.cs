using CoffeeShop.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations.IdentityConfigurations;

internal class UserConfiguration : IEntityConfiguration<User>
{
    public EntityTypeBuilder<User> Configure(EntityTypeBuilder<User> builder)
    {
        throw new NotImplementedException();
    }
}