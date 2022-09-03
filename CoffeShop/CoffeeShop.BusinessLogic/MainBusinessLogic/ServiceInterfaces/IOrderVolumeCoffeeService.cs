using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IOrderVolumeCoffeeService
{
    Task<IEnumerable<OrderVolumeCoffee>> GetAllAsync();

    public Task<OrderVolumeCoffee?> GetAsync(int id);

    Task CreateAsync(OrderVolumeCoffee orderVolumeCoffee);

    Task UpdateAsync(OrderVolumeCoffee orderVolumeCoffee);
    
    Task DeleteAsync(OrderVolumeCoffee orderVolumeCoffee);
}