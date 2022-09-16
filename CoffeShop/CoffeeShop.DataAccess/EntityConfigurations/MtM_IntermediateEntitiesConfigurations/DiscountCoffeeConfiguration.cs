using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations.MtM_IntermediateEntitiesConfigurations;

public class DiscountCoffeeConfiguration : IEntityConfiguration<DiscountCoffee>, IDefaultDataSetter<DiscountCoffee>
{
    public EntityTypeBuilder<DiscountCoffee> SetDefaultData(EntityTypeBuilder<DiscountCoffee> builder)
    {
        builder.HasData
        (
            new DiscountCoffee { DiscountId = 1, CoffeeId = 1 },
            new DiscountCoffee { DiscountId = 5, CoffeeId = 2 },
            new DiscountCoffee { DiscountId = 4, CoffeeId = 5 },
            new DiscountCoffee { DiscountId = 2, CoffeeId = 6 },
            new DiscountCoffee { DiscountId = 3, CoffeeId = 3 },
            new DiscountCoffee { DiscountId = 2, CoffeeId = 7 }
        );
        return builder;
    }

    public EntityTypeBuilder<DiscountCoffee> Configure(EntityTypeBuilder<DiscountCoffee> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName(() => nameof(DiscountCoffee)));

        builder.HasKey(x => new { CoffeetId = x.CoffeeId, x.DiscountId });

        builder
            .HasOne(x => x.Discount)
            .WithMany(x => x.DiscountCoffees)
            .HasForeignKey(x => x.DiscountId);
        builder
            .HasOne(x => x.Coffee)
            .WithMany(x => x.DiscountCoffees)
            .HasForeignKey(x => x.CoffeeId);

        return builder;
    }
}