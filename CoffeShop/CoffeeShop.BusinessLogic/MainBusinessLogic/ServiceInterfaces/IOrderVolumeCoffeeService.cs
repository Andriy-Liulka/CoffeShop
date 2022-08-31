using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IOrderVolumeCoffeeService
{
    Task<List<OrderVolumeCoffee>> GetAllAsync();

    Task<OrderVolumeCoffee?> GetAsync(int orderId, int volumeId, int coffeeId);

    Task CreateAsync(OrderVolumeCoffee orderVolumeCoffee);

    Task UpdateAsync(OrderVolumeCoffee orderVolumeCoffee);
    
    Task DeleteAsync(OrderVolumeCoffee orderVolumeCoffee);
}