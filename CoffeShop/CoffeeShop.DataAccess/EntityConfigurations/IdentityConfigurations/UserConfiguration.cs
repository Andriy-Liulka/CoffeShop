using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Constants;
using CoffeeShop.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations.IdentityConfigurations;

internal class UserConfiguration : IEntityConfiguration<User>,IDefaultDataSetter<User>
{
    public EntityTypeBuilder<User> Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName(()=>nameof(User)));

        builder.HasKey(x => x.Login);
        
        builder.Ignore(x => x.Orders);
        
        builder
            .HasOne(x => x.Role)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.RoleName);
        builder
            .HasMany(x => x.Orders)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserLogin);
        
        builder
            .HasOne(x => x.IdentityCredential)
            .WithOne(x => x.User)
            .HasForeignKey<User>(x=>x.IdentityCredentialLogin);
        
        return builder;
    }

    public EntityTypeBuilder<User> SetDefaultData(EntityTypeBuilder<User> builder)
    {
        builder.HasData(new User
        {
            FirstName = "Admin",
            LastName = "Admin",
            Email = "Admin@example.com",
            IsBlocked = false,
            RoleName = Roles.Admin,
            Bonuses = 0,
            PasswordHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918"
        });
        return builder;
    }
}