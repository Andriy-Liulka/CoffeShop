using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using CoffeeShop.Domain.Entities;

namespace CoffeShop.Api.dto.Ui;

public class CoffeeUi
{
    public long Id { get; set; }
    public bool IsMilk { get; set; }

    public string Name { get; set; }

    public string Provider { get; set; }

    public long BonusesSize { get; set; }

    public virtual IList<BonusCoffeeUi>? BonusCoffees { get; set; }

    public virtual IList<OrderVolumeCoffeeUi>? OrderVolumeCoffees { get; set; }

    public virtual IList<DiscountCoffeeUi>? DiscountCoffees { get; set; }
}

