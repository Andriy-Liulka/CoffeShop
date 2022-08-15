using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations.MtM_IntermediateEntitiesConfigurations;

public class DiscountCoffeeConfiguration : IEntityConfiguration<DiscountCoffee>,IDefaultDataSetter<DiscountCoffee>
{
    public EntityTypeBuilder<DiscountCoffee> Configure(EntityTypeBuilder<DiscountCoffee> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName(()=>nameof(DiscountCoffee)));

        builder.HasKey(x=>new{x.CoffeetId,x.DiscountId});

        builder
            .HasOne(x => x.Discount)
            .WithMany(x => x.Discount_Coffees)
            .HasForeignKey(x => x.DiscountId);

        builder
            .HasOne(x => x.Coffee)
            .WithMany(x => x.Discount_Coffees)
            .HasForeignKey(x => x.CoffeetId);

        return builder;
    }

    public EntityTypeBuilder<DiscountCoffee> SetDefaultData(EntityTypeBuilder<DiscountCoffee> builder)
    {
        throw new NotImplementedException();
    }
}