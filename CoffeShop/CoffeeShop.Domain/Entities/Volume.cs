using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;

namespace CoffeeShop.Domain.Entities;

public class Volume
{
    public long Id { get; set; }
    
    public int Capacity { get; set; }
    
    public string Name { get; set; }
    
    public virtual IList<OrderVolumeCoffee> OrderVolumeCoffees { get; set; }
    
    public virtual IList<BonusCoffee> BonusCoffees { get; set; }
}