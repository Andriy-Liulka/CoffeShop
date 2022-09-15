using CoffeeShop.Domain.Entities;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.CoffeeRepositories;

public interface ICoffeeRepository : IRepository<Coffee>
{
    public Task<Coffee> GetAsync(int id);
}