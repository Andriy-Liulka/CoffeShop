using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations.IdentityConfigurations;

internal class UserConfiguration : IEntityConfiguration<User>
{
    public EntityTypeBuilder<User> Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName<User>());

        return builder;
    }
}