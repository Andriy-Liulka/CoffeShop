using CoffeeShop.Domain.Entities.Identity;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetAllAsync();

    Task<Role?> GetAsync(string name);
}