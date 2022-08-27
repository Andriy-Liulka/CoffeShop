using CoffeeShop.Domain.Entities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IOrderService
{
    public Task<List<Order>> GetAllAsync();

    public Task<Order?> GetAsync(int id);

    public Task CreateAsync(Order order);

    public Task UpdateAsync(Order order);

    public Task DeleteAsync(Order order);
}