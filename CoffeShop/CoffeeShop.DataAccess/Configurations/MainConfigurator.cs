using CoffeeShop.DataAccess.EntityConfigurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace CoffeeShop.DataAccess.Configurations;

public static class Configurator
{
    public static EntityTypeBuilder<TEntity> Configure<TConfiguration,TEntity>(this EntityTypeBuilder<TEntity> entity) 
        where TConfiguration : IEntityConfiguration<TEntity>, new()
        where TEntity : class
    => new TConfiguration().Configure(entity);
    
    public static EntityTypeBuilder<TEntity> SetDefaultData<TConfiguration, TEntity>(this EntityTypeBuilder<TEntity> entity) 
        where TConfiguration : IDefaultDataSetter<TEntity>, new()
        where TEntity : class
        => new TConfiguration().SetDefaultData(entity);
}