using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IOrderVolumeCoffeeService
{
    public Task<List<OrderVolumeCoffee>> GetAllAsync();

    public Task<OrderVolumeCoffee?> GetAsync(int orderId, int volumeId, int coffeeId);

    public Task CreateAsync(OrderVolumeCoffee orderVolumeCoffee);

    public Task UpdateAsync(OrderVolumeCoffee orderVolumeCoffee);
    
    public Task DeleteAsync(OrderVolumeCoffee orderVolumeCoffee);
}