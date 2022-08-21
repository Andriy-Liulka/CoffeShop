using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations.MtM_IntermediateEntitiesConfigurations;

public class OrderVolumeCoffeeConfiguration : IEntityConfiguration<OrderVolumeCoffee>,IDefaultDataSetter<OrderVolumeCoffee>
{
    public EntityTypeBuilder<OrderVolumeCoffee> Configure(EntityTypeBuilder<OrderVolumeCoffee> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName(() => nameof(OrderVolumeCoffee)));

        builder.HasKey(x => new {x.OrderId, x.VolumeId, x.CoffeetId});
        
        builder.Property(pr => pr.Price).HasColumnType("DECIMAL(15,7)");
        
        builder
            .HasOne(x => x.Order)
            .WithMany(x => x.OrderVolumeCoffees)
            .HasForeignKey(x => x.OrderId);

        builder
            .HasOne(x => x.Volume)
            .WithMany(x => x.OrderVolumeCoffees)
            .HasForeignKey(x => x.VolumeId);

        builder
            .HasOne(x => x.Coffee)
            .WithMany(x => x.OrderVolumeCoffees)
            .HasForeignKey(x => x.CoffeetId);

        return builder;
    }

    public EntityTypeBuilder<OrderVolumeCoffee> SetDefaultData(EntityTypeBuilder<OrderVolumeCoffee> builder)
    {
        throw new NotImplementedException();
    }
}