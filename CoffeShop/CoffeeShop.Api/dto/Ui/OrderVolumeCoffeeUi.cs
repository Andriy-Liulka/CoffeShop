using CoffeeShop.Domain.Entities;

namespace CoffeShop.Api.dto.Ui;

public class OrderVolumeCoffeeUi
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public virtual OrderUi? Order { get; set; }

    public long VolumeId { get; set; }
    public virtual VolumeUi? Volume { get; set; }

    public long CoffeetId { get; set; }
    public virtual CoffeeUi? Coffee { get; set; }
    public decimal Price { get; set; }
}

