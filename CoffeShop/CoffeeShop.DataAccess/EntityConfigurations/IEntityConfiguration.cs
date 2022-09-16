using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations;

public interface IEntityConfiguration<TEntityType> where TEntityType : class
{
    public EntityTypeBuilder<TEntityType> Configure(EntityTypeBuilder<TEntityType> builder);
}