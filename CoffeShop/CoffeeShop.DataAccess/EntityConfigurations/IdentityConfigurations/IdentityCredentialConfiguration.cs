using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations.IdentityConfigurations;

public class IdentityCredentialConfiguration : IEntityConfiguration<IdentityCredential>,
    IDefaultDataSetter<IdentityCredential>
{
    public EntityTypeBuilder<IdentityCredential> SetDefaultData(EntityTypeBuilder<IdentityCredential> builder)
    {
        builder.HasData(new IdentityCredential
        {
            Login = "AdminAdmin",
            RefreshToken = null,
            ValidTo = null
        });
        return builder;
    }

    public EntityTypeBuilder<IdentityCredential> Configure(EntityTypeBuilder<IdentityCredential> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName(() => nameof(IdentityCredential)));

        builder.HasKey(x => x.Login);

        builder.Ignore(x => x.User);

        builder
            .HasOne(x => x.User)
            .WithOne(x => x.IdentityCredential)
            .HasForeignKey<IdentityCredential>(x => x.Login);

        return builder;
    }
}