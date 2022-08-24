using CoffeeShop.Domain.Entities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface ICoffeeService
{
    public Task<List<Coffee>> GetAllAsync();
    public Task<Coffee?> GetAsync(int id);
    Task CreateAsync(Coffee coffee);
    Task UpdateAsync(Coffee coffee);
    Task DeleteAsync(Coffee coffee);
}