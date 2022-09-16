using CoffeeShop.DataAccess.EntityConfigurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.Configurations;

public static class Configurator
{
    public static EntityTypeBuilder<TEntityType> Configure<TEntity,TEntityType>(this EntityTypeBuilder<TEntityType> entity) 
        where TEntity : IEntityConfiguration<TEntityType>, new()
        where TEntityType : class
    => new TEntity().Configure(entity);
    
    public static EntityTypeBuilder<TEntityType> SetDefaultData<TEntity,TEntityType>(this EntityTypeBuilder<TEntityType> entity) 
        where TEntity : IDefaultDataSetter<TEntityType>, new()
        where TEntityType : class
        => new TEntity().SetDefaultData(entity);
}