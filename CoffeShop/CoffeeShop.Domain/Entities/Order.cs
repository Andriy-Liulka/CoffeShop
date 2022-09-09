using CoffeeShop.Domain.Entities.Identity;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using CoffeeShop.Domain.Enums;

namespace CoffeeShop.Domain.Entities;

public class Order
{
    public long Id { get; set; }
    
    public DateTimeOffset RegistrationDate { get; set; }
    
    public decimal TotalPrice { get; set; }
    
    public long TotalBonusesSize { get; set; }
    
    public bool IsDelivered { get; set; }
    
    public DeliveryWays DeliveryWay { get; set; }

    public string UserLogin { get; set; }

    public virtual User User { get; set; }

    public virtual IList<OrderVolumeCoffee>? OrderVolumeCoffees { get; set; }
}