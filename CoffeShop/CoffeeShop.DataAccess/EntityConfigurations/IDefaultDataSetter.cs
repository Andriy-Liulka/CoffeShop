using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations;

public interface IDefaultDataSetter<TEntityType> where TEntityType : class
{
    public EntityTypeBuilder<TEntityType> SetDefaultData(EntityTypeBuilder<TEntityType> builder);
}