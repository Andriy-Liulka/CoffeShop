using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations;

public class BonusCoffeeConfiguration : IEntityConfiguration<BonusCoffee>,IDefaultDataSetter<BonusCoffee>
{
    public EntityTypeBuilder<BonusCoffee> Configure(EntityTypeBuilder<BonusCoffee> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName(()=>nameof(BonusCoffee)));

        builder
            .HasOne(x => x.Coffee)
            .WithMany(x => x.BonusCoffees)
            .HasForeignKey(x => x.CoffeeId);
        
        builder
            .HasOne(x => x.Volume)
            .WithMany(x => x.BonusCoffees)
            .HasForeignKey(x => x.VolumeId);
        
        return builder;
    }

    public EntityTypeBuilder<BonusCoffee> SetDefaultData(EntityTypeBuilder<BonusCoffee> builder)
    {
        builder.HasData
        (
            new BonusCoffee{Id = 1, BonusPrice = 200, VolumeId = 1, CoffeeId = 1},
            new BonusCoffee{Id = 2, BonusPrice = 250, VolumeId = 3, CoffeeId = 7},
            new BonusCoffee{Id = 3, BonusPrice = 310, VolumeId = 5, CoffeeId = 4},
            new BonusCoffee{Id = 4, BonusPrice = 435, VolumeId = 4, CoffeeId = 2},
            new BonusCoffee{Id = 5, BonusPrice = 500, VolumeId = 6, CoffeeId = 7}
        );
        return builder;
    }
}