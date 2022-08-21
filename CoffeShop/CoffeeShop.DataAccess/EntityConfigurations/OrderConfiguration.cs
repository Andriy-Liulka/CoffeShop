using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations;

public class OrderConfiguration : IEntityConfiguration<Order>,IDefaultDataSetter<Order>
{
    public EntityTypeBuilder<Order>Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName(()=>nameof(Order)));

        builder.HasKey(x=>x.Id);
        
        builder.Property(pr => pr.TotalPrice).HasColumnType("DECIMAL(20,10)");
        
        builder.Property(pr => pr.DeliveryWay).HasColumnType("VARCHAR(10)");
        
        builder.Property(pr => pr.RegistrationDate).HasColumnType("DATETIMEOFFSET(4)");

        builder
            .HasMany(x => x.OrderVolumeCoffees)
            .WithOne(x => x.Order)
            .HasForeignKey(x => x.OrderId);
        
        builder
            .HasOne(x=>x.User)
            .WithMany(x=>x.Orders)
            .HasForeignKey(x=>x.UserId);
        
        return builder;
    }

    public EntityTypeBuilder<Order> SetDefaultData(EntityTypeBuilder<Order> builder)
    {
        throw new NotImplementedException();
    }
}