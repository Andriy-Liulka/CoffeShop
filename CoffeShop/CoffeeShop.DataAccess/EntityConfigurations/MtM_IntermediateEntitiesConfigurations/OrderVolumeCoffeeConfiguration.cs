using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations.MtM_IntermediateEntitiesConfigurations;

public class OrderVolumeCoffeeConfiguration : IEntityConfiguration<Order_Volume_Coffee>
{
    public EntityTypeBuilder<Order_Volume_Coffee> Configure(EntityTypeBuilder<Order_Volume_Coffee> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName(() => nameof(Order_Volume_Coffee)));

        builder.HasKey(x => new {x.OrderId, x.VolumeId, x.CoffeetId});
        builder
            .HasOne(x => x.Order)
            .WithMany(x => x.Order_Volume_Coffees)
            .HasForeignKey(x => x.OrderId);

        builder
            .HasOne(x => x.Volume)
            .WithMany(x => x.Order_Volume_Coffees)
            .HasForeignKey(x => x.VolumeId);

        builder
            .HasOne(x => x.Coffee)
            .WithMany(x => x.Order_Volume_Coffees)
            .HasForeignKey(x => x.CoffeetId);

        return builder;
    }
}