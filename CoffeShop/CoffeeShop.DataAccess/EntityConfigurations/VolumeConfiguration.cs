using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations;

internal class VolumeConfiguration : IEntityConfiguration<Volume>
{
    public EntityTypeBuilder<Volume> Configure(EntityTypeBuilder<Volume> builder)
    {
        throw new NotImplementedException();
    }
}