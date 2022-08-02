
using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query;

namespace CoffeeShop.DataAccess.EntityConfigurations;

public class CoffeeConfiguration : IEntityConfiguration<Coffee>
{
    public EntityTypeBuilder<Coffee> Configure(EntityTypeBuilder<Coffee> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName(()=>nameof(Coffee)));
        
        builder.HasKey(x => x.Id);

        builder.Property(pr => pr.IsMilk).HasConversion<int>();

        builder.Property(pr => pr.Price).HasColumnType("DECIMAL(15,7)");

        builder
            .HasMany(x => x.BonusCoffees)
            .WithOne(x => x.Coffee)
            .HasForeignKey(x => x.CoffeeId);

        builder
            .HasMany(x => x.Order_Volume_Coffees)
            .WithOne(x => x.Coffee)
            .HasForeignKey(x => x.CoffeetId);

        builder
            .HasMany(x => x.Discount_Coffees)
            .WithOne(x => x.Coffee)
            .HasForeignKey(x => x.CoffeetId);
        
        return builder;
    }
}