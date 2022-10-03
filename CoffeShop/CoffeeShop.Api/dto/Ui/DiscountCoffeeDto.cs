using CoffeeShop.Domain.Entities;

namespace CoffeShop.Api.dto.Ui;

public class DiscountCoffeeDto
{
    public long DiscountId { get; set; }

    public long CoffeeId { get; set; }
}

