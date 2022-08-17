
using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query;

namespace CoffeeShop.DataAccess.EntityConfigurations;

public class CoffeeConfiguration : IEntityConfiguration<Coffee>,IDefaultDataSetter<Coffee>
{
    public EntityTypeBuilder<Coffee> Configure(EntityTypeBuilder<Coffee> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName(()=>nameof(Coffee)));
        
        builder.HasKey(x => x.Id);

        builder.Property(pr => pr.IsMilk).HasColumnType("INT");

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

    public EntityTypeBuilder<Coffee> SetDefaultData(EntityTypeBuilder<Coffee> builder)
    {
        builder.HasData
        (
            new Coffee{Id = 1, IsMilk = true, Name = "Latte", Provider = "United States", BonusesSize = 0},
            new Coffee{Id = 2, IsMilk = false, Name = "Americano", Provider = "North USA", BonusesSize = 10},
            new Coffee{Id = 3, IsMilk = true, Name = "Capuchino", Provider = "Italia", BonusesSize = 6},
            new Coffee{Id = 4, IsMilk = false, Name = "Ekspresso", Provider = "USA", BonusesSize = 15},
            new Coffee{Id = 5, IsMilk = true, Name = "Flat-White", Provider = "Australia", BonusesSize = 20},
            new Coffee{Id = 6, IsMilk = false, Name = "Mokachino", Provider = "USA", BonusesSize = 30},
            new Coffee{Id = 7, IsMilk = false, Name = "Black coffee", Provider = "Efiopia", BonusesSize = 3}
        );
        return builder;
    }
}