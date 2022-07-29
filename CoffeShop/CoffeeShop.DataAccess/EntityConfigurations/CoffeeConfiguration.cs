
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query;

namespace CoffeeShop.DataAccess.EntityConfigurations;

public class CoffeeConfiguration : IEntityConfiguration<Coffee>
{
    public EntityTypeBuilder<Coffee> Configure(EntityTypeBuilder<Coffee> builder)
    {
        builder.HasKey(x => x.Id);
        return builder;
    }
}