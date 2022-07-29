using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations.IdentityConfigurations;

public class RoleConfiguration : IEntityConfiguration<Role>
{
    public EntityTypeBuilder<Role> Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName<Role>());

        return builder;
    }
}