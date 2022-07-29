using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations.MtM_IntermediateEntitiesConfigurations;

public class Discount_Coffee_Configuration : IEntityConfiguration<Discount_Coffee>
{
    public EntityTypeBuilder<Discount_Coffee> Configure(EntityTypeBuilder<Discount_Coffee> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName(()=>nameof(Discount_Coffee)));

        return builder;
    }
}