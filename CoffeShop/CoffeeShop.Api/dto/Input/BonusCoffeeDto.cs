namespace CoffeShop.Api.Dto.Input;

public class BonusCoffeeDto
{
    public long Id { get; set; }

    public long BonusPrice { get; set; }
    public long? CoffeeId { get; set; }
    public long? VolumeId { get; set; }
}

