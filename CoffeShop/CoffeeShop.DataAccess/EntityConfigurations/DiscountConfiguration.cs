using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations;

internal class DiscountConfiguration :IEntityConfiguration<Discount>,IDefaultDataSetter<Discount>
{
    public EntityTypeBuilder<Discount> Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName(()=>nameof(Discount)));

        builder
            .HasMany(x => x.Discount_Coffees)
            .WithOne(x => x.Discount)
            .HasForeignKey(x => x.CoffeetId);

        return builder;
    }

    public EntityTypeBuilder<Discount> SetDefaultData(EntityTypeBuilder<Discount> builder)
    {
        builder.HasData(
            new Discount {Id = 1, Percent = 40},
            new Discount{Id = 2, Percent = 30},
            new Discount{Id = 3, Percent = 65},
            new Discount{Id = 4, Percent = 24},
            new Discount{Id = 4, Percent = 37});
        return builder;
    }
}