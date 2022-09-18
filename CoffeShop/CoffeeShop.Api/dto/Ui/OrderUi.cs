using CoffeeShop.Domain.Entities.Identity;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using CoffeeShop.Domain.Enums;

namespace CoffeShop.Api.dto.Ui;

public class OrderUi
{
    public long Id { get; set; }

    public DateTimeOffset RegistrationDate { get; set; }

    public decimal TotalPrice { get; set; }

    public long TotalBonusesSize { get; set; }

    public bool IsDelivered { get; set; }

    public DeliveryWays DeliveryWay { get; set; }

    public string UserLogin { get; set; }

}

