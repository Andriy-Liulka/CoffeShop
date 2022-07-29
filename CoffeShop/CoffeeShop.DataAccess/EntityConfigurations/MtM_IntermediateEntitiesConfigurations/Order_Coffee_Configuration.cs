using CoffeeShop.DataAccess.Common;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShop.DataAccess.EntityConfigurations.MtM_IntermediateEntitiesConfigurations;

public class Order_Coffee_Configuration : IEntityConfiguration<Order_Coffee>
{
    public EntityTypeBuilder<Order_Coffee> Configure(EntityTypeBuilder<Order_Coffee> builder)
    {
        builder.ToTable(TableNameCreator.CreateDefaultTableName(()=>nameof(Order_Coffee)));

        return builder;
    }
}