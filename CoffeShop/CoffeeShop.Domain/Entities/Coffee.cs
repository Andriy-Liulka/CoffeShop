namespace CoffeeShop.Domain.Entities;

public class Coffee
{
    public long Id { get; set; }
    
    public bool IsMilk { get; set; }
    
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public string Provider { get; set; }
}