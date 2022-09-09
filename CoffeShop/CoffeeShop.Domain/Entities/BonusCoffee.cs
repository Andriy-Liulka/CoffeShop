namespace CoffeeShop.Domain.Entities;

public class BonusCoffee
{
    public long Id { get; set; }
    
    public long BonusPrice { get; set; }
    public long? CoffeeId { get; set; }
    public virtual Coffee? Coffee { get; set; }
    
    public long? VolumeId { get; set; }
    
    public virtual Volume? Volume { get; set; }

}