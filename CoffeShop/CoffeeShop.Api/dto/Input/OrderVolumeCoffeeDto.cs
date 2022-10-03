namespace CoffeShop.Api.Dto.Input;

public class OrderVolumeCoffeeDto
{
    public long Id { get; set; }
    public long OrderId { get; set; }

    public long VolumeId { get; set; }

    public long CoffeetId { get; set; }
    public decimal Price { get; set; }
}

