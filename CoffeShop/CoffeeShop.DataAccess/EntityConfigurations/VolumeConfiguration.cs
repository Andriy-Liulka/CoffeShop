using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations;

internal class VolumeConfiguration : IEntityConfiguration<Volume>
{
    public EntityTypeBuilder<Volume> Configure(EntityTypeBuilder<Volume> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName<Volume>());

        return builder;
    }
}