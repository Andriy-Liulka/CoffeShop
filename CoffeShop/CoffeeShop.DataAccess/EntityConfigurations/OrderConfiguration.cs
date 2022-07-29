using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CoffeeShop.DataAccess.EntityConfigurations;

public class OrderConfiguration : IEntityConfiguration<Order>
{
    public EntityTypeBuilder<Order>Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName(()=>nameof(Order)));
        
        builder.Property(pr => pr.TotalPrice).HasColumnType("DECIMAL(20,10)");
        builder.Property(pr => pr.DeliveryWay).HasColumnType("VARCHAR(10)");
        return builder;
    }
}