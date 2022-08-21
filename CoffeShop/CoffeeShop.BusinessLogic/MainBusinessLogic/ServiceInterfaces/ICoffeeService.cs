using CoffeeShop.Domain.Entities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface ICoffeeService
{
    public Task<List<Coffee>> GetAll();
    public Task<Coffee?> Get(int id);
}