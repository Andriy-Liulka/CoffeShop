using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CoffeeShop.DataAccess.EntityConfigurations;

public class OrderConfiguration : IEntityConfiguration<Order>
{
    public EntityTypeBuilder<Order>Configure(EntityTypeBuilder<Order> builder)
    {
        throw new NotImplementedException();
    }
}