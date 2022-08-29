namespace CoffeeShop.Domain.Entities.MtM_IntermediateEntities;

public class OrderVolumeCoffee
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public virtual Order Order { get; set; }
    
    public long VolumeId { get; set; }
    public virtual Volume Volume { get; set; }
    
    public long CoffeetId { get; set; }
    public virtual Coffee Coffee { get; set; }
    public decimal Price { get; set; }
}