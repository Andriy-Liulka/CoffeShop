using CoffeeShop.Domain.Entities.Identity;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IRoleService
{
    public Task<List<Role>> GetAllAsync();

    public Task<Role?> GetAsync(int userId);
}