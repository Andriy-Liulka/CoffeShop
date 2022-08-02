namespace CoffeeShop.Domain.Entities.MtM_IntermediateEntities;

public class Order_Volume_Coffee
{
    public long OrderId { get; set; }
    public virtual Order Order { get; set; }
    
    public long VolumeId { get; set; }
    public virtual Volume Volume { get; set; }
    
    public long CoffeetId { get; set; }
    public virtual Coffee Coffee { get; set; }
}