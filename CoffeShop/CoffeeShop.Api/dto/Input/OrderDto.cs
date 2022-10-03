using CoffeeShop.Domain.Enums;

namespace CoffeShop.Api.Dto.Input;

public class OrderDto
{
    public long Id { get; set; }

    public DateTimeOffset RegistrationDate { get; set; }

    public decimal TotalPrice { get; set; }

    public long TotalBonusesSize { get; set; }

    public bool IsDelivered { get; set; }

    public DeliveryWays DeliveryWay { get; set; }

}

