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
        throw new NotImplementedException();
    }
}