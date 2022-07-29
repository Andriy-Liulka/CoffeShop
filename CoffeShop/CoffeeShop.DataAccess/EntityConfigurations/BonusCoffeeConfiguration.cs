using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations;

public class BonusCoffeeConfiguration : IEntityConfiguration<BonusCoffee>
{
    public EntityTypeBuilder<BonusCoffee> Configure(EntityTypeBuilder<BonusCoffee> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName(()=>nameof(BonusCoffee)));

        return builder;
    }
}