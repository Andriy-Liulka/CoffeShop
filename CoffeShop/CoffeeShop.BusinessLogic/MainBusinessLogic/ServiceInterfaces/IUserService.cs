using CoffeeShop.Domain.Entities.Identity;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllAsync();

    Task<User?> GetAsync(int userId);

    Task CreateAsync(User user);

    Task UpdateAsync(User user);
    
    Task DeleteAsync(User user);
}