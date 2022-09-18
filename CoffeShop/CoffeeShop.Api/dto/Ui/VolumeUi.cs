using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using CoffeeShop.Domain.Entities;

namespace CoffeShop.Api.dto.Ui;

public class VolumeUi
{
    public long Id { get; set; }

    public int Capacity { get; set; }

    public string Name { get; set; }

    public virtual IList<OrderVolumeCoffeeUi>? OrderVolumeCoffees { get; set; }

    public virtual IList<BonusCoffeeUi>? BonusCoffees { get; set; }
}

