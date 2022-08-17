using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations.IdentityConfigurations;

public class RoleConfiguration : IEntityConfiguration<Role>,IDefaultDataSetter<Role>
{
    public EntityTypeBuilder<Role> Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName(()=>nameof(Role)));

        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.Users)
            .WithOne(x => x.Role)
            .HasForeignKey(x=>x.RoleId);
        
        return builder;
    }

    public EntityTypeBuilder<Role> SetDefaultData(EntityTypeBuilder<Role> builder)
    {
        builder.HasData
        (
            new Role {Id = 1, Name = "Admin"},
            new Role {Id = 2, Name = "Customer"}
        );
        return builder;
    }
}