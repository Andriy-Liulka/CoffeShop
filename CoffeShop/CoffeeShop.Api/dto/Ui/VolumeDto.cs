using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using CoffeeShop.Domain.Entities;

namespace CoffeShop.Api.dto.Ui;

public class VolumeDto
{
    public long Id { get; set; }

    public int Capacity { get; set; }

    public string Name { get; set; }
}

