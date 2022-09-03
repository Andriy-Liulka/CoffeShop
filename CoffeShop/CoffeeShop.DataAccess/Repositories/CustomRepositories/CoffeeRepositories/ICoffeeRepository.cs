using CoffeeShop.Domain.Entities;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.CoffeeRepositories;

public interface ICoffeeRepository
{
    public Task<Coffee> GetAsync(int id);
}