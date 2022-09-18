using CoffeeShop.Domain.Entities;

namespace CoffeShop.Api.dto.Ui;

public class BonusCoffeeUi
{
    public long Id { get; set; }

    public long BonusPrice { get; set; }
    public long? CoffeeId { get; set; }
    public virtual CoffeeUi? Coffee { get; set; }

    public long? VolumeId { get; set; }

    public virtual VolumeUi? Volume { get; set; }
}

