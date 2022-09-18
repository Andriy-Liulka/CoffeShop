using CoffeeShop.Domain.Entities;

namespace CoffeShop.Api.dto.Ui;

public class DiscountCoffeeUi
{
    public long DiscountId { get; set; }
    public virtual DiscountUi? Discount { get; set; }

    public long CoffeeId { get; set; }
    public virtual CoffeeUi? Coffee { get; set; }
}

