using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations;

internal class DiscountConfiguration :IEntityConfiguration<Discount>
{
    public EntityTypeBuilder<Discount> Configure(EntityTypeBuilder<Discount> builder)
    {
        throw new NotImplementedException();
    }
}