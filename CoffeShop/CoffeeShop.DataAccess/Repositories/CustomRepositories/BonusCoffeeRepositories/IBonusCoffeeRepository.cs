using CoffeeShop.Domain.Entities;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.BonusCoffeeRepositories;

public interface IBonusCoffeeRepository
{
    public Task<BonusCoffee> GetAsync(int id);
}