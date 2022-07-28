using CoffeeShop.DataAccess.EntityConfigurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.Configurations;

public static class Configurator
{
    public static void Configure<TEntity>(this EntityTypeBuilder entity) where TEntity : IEntityConfiguration,new()
    =>new TEntity().Configure(entity);
}