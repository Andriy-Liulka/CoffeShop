using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations.MtM_IntermediateEntitiesConfigurations;

public class DiscountCoffeeConfiguration : IEntityConfiguration<Discount_Coffee>
{
    public EntityTypeBuilder<Discount_Coffee> Configure(EntityTypeBuilder<Discount_Coffee> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName(()=>nameof(Discount_Coffee)));

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
}