using CoffeeShop.Domain.Entities;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.DiscountRepositories;

public interface IDiscountRepository : IRepository<Discount>
{
    public Task<Discount> GetAsync(long id);
}