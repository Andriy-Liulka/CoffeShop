using CoffeeShop.Domain.Entities;

namespace CoffeShop.Api.dto.Ui;

public class OrderVolumeCoffeeDto
{
    public long Id { get; set; }
    public long OrderId { get; set; }

    public long VolumeId { get; set; }

    public long CoffeetId { get; set; }
    public decimal Price { get; set; }
}

