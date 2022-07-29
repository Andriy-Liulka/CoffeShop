using CoffeeShop.DataAccess.EntityConfigurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.Configurations;

public static class Configurator
{
    public static void Configure<TEntity,TEntityType>(this EntityTypeBuilder<TEntityType> entity) 
        where TEntity : IEntityConfiguration<TEntityType>,new()
        where TEntityType : class
    =>new TEntity().Configure(entity);
}