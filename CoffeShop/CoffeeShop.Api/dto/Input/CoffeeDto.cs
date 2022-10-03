namespace CoffeShop.Api.Dto.Input;

public class CoffeeDto
{
    public long Id { get; set; }
    public bool IsMilk { get; set; }

    public string Name { get; set; }

    public string Provider { get; set; }

    public long BonusesSize { get; set; }
}

