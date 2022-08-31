using CoffeeShop.Domain.Entities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface ICoffeeService
{
    Task<IEnumerable<Coffee>> GetAllAsync();
    Task<Coffee?> GetAsync(int id);
    Task CreateAsync(Coffee coffee);
    Task UpdateAsync(Coffee coffee);
    Task DeleteAsync(Coffee coffee);
}