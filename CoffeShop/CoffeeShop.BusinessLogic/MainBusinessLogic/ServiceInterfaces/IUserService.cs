using CoffeeShop.Domain.Entities.Identity;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IUserService
{
    public Task<List<User>> GetAllAsync();

    public Task<User?> GetAsync(int userId);

    public  Task CreateAsync(User user);

    public Task UpdateAsync(User user);
    
    public Task DeleteAsync(User user);
}