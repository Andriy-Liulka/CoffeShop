using CoffeeShop.Domain.Entities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface ICoffeeService
{
    public Task<List<Coffee>> GetAllAsync();
    public Task<Coffee?> GetAsync(int id);
}