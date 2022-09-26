using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Constants;
using CoffeeShop.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations.IdentityConfigurations;

internal class UserConfiguration : IEntityConfiguration<User>, IDefaultDataSetter<User>
{
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
            IdentityCredentialLogin = "AdminAdmin",
            PasswordHash = "99020f0c7a3c89db3327840236da5da44c79cab9f7d1f7ba740fc00bccaee965"
        });
        return builder;
    }

    public EntityTypeBuilder<User> Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName(() => nameof(User)));

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
            .HasForeignKey<User>(x => x.IdentityCredentialLogin);

        return builder;
    }
}