using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations;

internal class VolumeConfiguration : IEntityConfiguration<Volume>, IDefaultDataSetter<Volume>
{
    public EntityTypeBuilder<Volume> SetDefaultData(EntityTypeBuilder<Volume> builder)
    {
        builder.HasData
        (
            new Volume { Id = 1, Capacity = 200, Name = "Small" },
            new Volume { Id = 2, Capacity = 250, Name = "Small" },
            new Volume { Id = 3, Capacity = 300, Name = "Average" },
            new Volume { Id = 4, Capacity = 350, Name = "Average" },
            new Volume { Id = 5, Capacity = 450, Name = "Large" },
            new Volume { Id = 6, Capacity = 500, Name = "Large" }
        );
        return builder;
    }

    public EntityTypeBuilder<Volume> Configure(EntityTypeBuilder<Volume> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName(() => nameof(Volume)));

        builder.HasKey(x => x.Id);

        builder.Ignore(x => x.BonusCoffees);
        builder.Ignore(x => x.OrderVolumeCoffees);

        builder.HasMany(x => x.OrderVolumeCoffees)
            .WithOne(x => x.Volume)
            .HasForeignKey(x => x.VolumeId);
        builder.HasMany(x => x.BonusCoffees)
            .WithOne(x => x.Volume)
            .HasForeignKey(x => x.VolumeId);

        return builder;
    }
}