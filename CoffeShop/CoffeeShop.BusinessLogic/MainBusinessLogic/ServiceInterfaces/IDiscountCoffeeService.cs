using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IDiscountCoffeeService
{
    Task<IEnumerable<DiscountCoffee>> GetAllAsync();

    Task<DiscountCoffee?> GetAsync(int discountId, int coffeetId);

    Task CreateAsync(DiscountCoffee discountCoffee);

    Task UpdateAsync(DiscountCoffee discountCoffee);

    Task DeleteAsync(DiscountCoffee discountCoffee);
}