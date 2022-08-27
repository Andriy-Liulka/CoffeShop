using CoffeeShop.Domain.Entities.Identity;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IUserService
{
    public Task<List<User>> GetAllAsync();

    public Task<User?> GetAsync(int userId);

    public  Task CreateAsync(DiscountCoffee discountCoffee);

    public Task UpdateAsync(DiscountCoffee discountCoffee);
    
    public Task DeleteAsync(DiscountCoffee discountCoffee);
}