using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations;

public interface IEntityConfiguration
{
    public EntityTypeBuilder Configure(EntityTypeBuilder builder);
}