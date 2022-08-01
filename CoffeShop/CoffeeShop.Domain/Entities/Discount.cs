using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;

namespace CoffeeShop.Domain.Entities;

public class Discount
{
    public long Id { get; set; }
    
    public float Percent { get; set; }

    public virtual IList<Discount_Coffee> Discount_Coffees { get; set; }
}