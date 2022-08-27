using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IDiscountCoffeeService
{
    public Task<List<DiscountCoffee>> GetAllAsync();

    public Task<DiscountCoffee?> GetAsync(int discountId, int coffeetId);

    public Task CreateAsync(DiscountCoffee discountCoffee);

    public Task UpdateAsync(DiscountCoffee discountCoffee);

    public Task DeleteAsync(DiscountCoffee discountCoffee);
}