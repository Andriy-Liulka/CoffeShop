using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;

namespace CoffeShop.Api.dto.Ui;

public class DiscountUi
{
    public long Id { get; set; }

    public float Percent { get; set; }

    public virtual IList<DiscountCoffeeUi>? DiscountCoffees { get; set; }
}

