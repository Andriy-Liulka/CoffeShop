using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;

namespace CoffeeShop.Domain.Entities;

public class Coffee
{
    public long Id { get; set; }
    public bool IsMilk { get; set; }
    
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public string Provider { get; set; }
    
    public long BonusesSize { get; set; }
    
    public virtual IList<BonusCoffee> BonusCoffees { get; set; }

    public virtual IList<Order_Volume_Coffee> Order_Volume_Coffees { get; set; }
    
    public virtual IList<Discount_Coffee> Discount_Coffees { get; set; }
}