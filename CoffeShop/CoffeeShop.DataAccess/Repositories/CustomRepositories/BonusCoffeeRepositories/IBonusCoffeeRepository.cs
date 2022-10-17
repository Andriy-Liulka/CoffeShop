using CoffeeShop.Domain.Entities;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.BonusCoffeeRepositories;

public interface IBonusCoffeeRepository : IRepository<BonusCoffee>
{
    public Task<BonusCoffee> GetAsync(long id);
}