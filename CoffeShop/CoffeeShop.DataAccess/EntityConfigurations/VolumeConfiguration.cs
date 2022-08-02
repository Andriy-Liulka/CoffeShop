using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations;

internal class VolumeConfiguration : IEntityConfiguration<Volume>
{
    public EntityTypeBuilder<Volume> Configure(EntityTypeBuilder<Volume> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName(()=>nameof(Volume)));

        builder.HasMany(x => x.Order_Volume_Coffees)
            .WithOne(x => x.Volume)
            .HasForeignKey(x => x.VolumeId);
        
        builder.HasMany(x => x.BonusCoffees)
            .WithOne(x => x.Volume)
            .HasForeignKey(x => x.VolumeId);

        return builder;
    }
}