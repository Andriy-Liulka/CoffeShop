using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.DiscountCoffeeRepositories;

public interface IDiscountCoffeeRepository : IRepository<DiscountCoffee>
{
    public Task<DiscountCoffee> GetAsync(int discountId, int coffeetId);
}