using CoffeeShop.Domain.Entities.Identity;
using CoffeeShop.Domain.Enums;

namespace CoffeeShop.Domain.Entities;

public class Order
{
    public long Id { get; set; }
    
    public DateTimeOffset RegistrationDate { get; set; }
    
    public decimal TotalPrice { get; set; }
    
    public bool IsDelivered { get; set; }
    
    public DeliveryWays DeliveryWay { get; set; }

    public long UserId { get; set; }

    public virtual User User { get; set; }

    public virtual IList<Coffee> Coffees { get; set; }
}