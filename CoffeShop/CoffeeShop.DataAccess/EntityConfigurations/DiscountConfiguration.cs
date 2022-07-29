using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations;

internal class DiscountConfiguration :IEntityConfiguration<Discount>
{
    public EntityTypeBuilder<Discount> Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName(()=>nameof(Discount)));
        
        return builder;
    }
}