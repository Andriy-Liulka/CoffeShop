namespace CoffeeShop.Domain.Entities.MtM_IntermediateEntities;

public class Discount_Coffee
{
    public long DiscountId { get; set; }
    public virtual Discount Discount { get; set; }
    
    public long CoffeetId { get; set; }
    public virtual Coffee Coffee { get; set; }
}