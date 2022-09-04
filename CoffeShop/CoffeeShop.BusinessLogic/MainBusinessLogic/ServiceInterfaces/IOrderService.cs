using CoffeeShop.Domain.Entities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync();

    Task<Order?> GetAsync(int id);

    Task CreateAsync(Order order);

    Task UpdateAsync(Order order);

    Task DeleteAsync(Order order);
}