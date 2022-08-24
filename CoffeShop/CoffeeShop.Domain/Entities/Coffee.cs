using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;

namespace CoffeeShop.Domain.Entities;

public class Coffee
{
    public long Id { get; set; }
    public bool IsMilk { get; set; }
    
    public string Name { get; set; }

    public string Provider { get; set; }
    
    public long BonusesSize { get; set; }
    
    public virtual IList<BonusCoffee>? BonusCoffees { get; set; }

    public virtual IList<OrderVolumeCoffee>? OrderVolumeCoffees { get; set; }
    
    public virtual IList<DiscountCoffee>? DiscountCoffees { get; set; }
}