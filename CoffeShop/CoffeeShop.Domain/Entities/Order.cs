using CoffeeShop.Domain.Enums;

namespace CoffeeShop.Domain.Entities;

public class Order
{
    public long Id { get; set; }
    
    public DateTimeOffset RegistrationDate { get; set; }
    
    public decimal TotalPrice { get; set; }
    
    public bool IsDelivered { get; set; }
    
    public DeliveryWays DeliveryWay { get; set; }
}