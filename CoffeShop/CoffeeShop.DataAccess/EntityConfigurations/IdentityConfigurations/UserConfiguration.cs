using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations.IdentityConfigurations;

internal class UserConfiguration : IEntityConfiguration<User>,IDefaultDataSetter<User>
{
    public EntityTypeBuilder<User> Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName(()=>nameof(User)));

        builder.HasKey(x => x.Id);
        
        builder.Ignore(x => x.Orders);
        
        builder
            .HasOne(x => x.Role)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.RoleId);
        builder
            .HasMany(x => x.Orders)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
        
        return builder;
    }

    public EntityTypeBuilder<User> SetDefaultData(EntityTypeBuilder<User> builder)
    {
        throw new NotImplementedException();
    }
}