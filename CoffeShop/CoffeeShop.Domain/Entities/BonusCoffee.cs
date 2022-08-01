namespace CoffeeShop.Domain.Entities;

public class BonusCoffee
{
    public long Id { get; set; }
    
    public long CoffeeId { get; set; }
    
    public Coffee Coffee { get; set; }
}