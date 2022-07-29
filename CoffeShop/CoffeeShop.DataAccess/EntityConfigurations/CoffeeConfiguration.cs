
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
        builder.ToTable(TableNameCreator.CreateDefaultTableName<Coffee>());
        
        builder.HasKey(x => x.Id);

        builder.Property(pr => pr.IsMilk).HasConversion<int>();

        
        return builder;
    }
}