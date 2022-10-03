using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using CoffeeShop.Domain.Entities;

namespace CoffeShop.Api.dto.Ui;

public class CoffeeDto
{
    public long Id { get; set; }
    public bool IsMilk { get; set; }

    public string Name { get; set; }

    public string Provider { get; set; }

    public long BonusesSize { get; set; }
}

