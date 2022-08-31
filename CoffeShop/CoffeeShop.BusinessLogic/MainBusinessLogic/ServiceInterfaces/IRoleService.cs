using CoffeeShop.Domain.Entities.Identity;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IRoleService
{
    Task<List<Role>> GetAllAsync();

    Task<Role?> GetAsync(int userId);
}