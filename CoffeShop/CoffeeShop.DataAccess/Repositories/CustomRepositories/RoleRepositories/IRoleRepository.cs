using CoffeeShop.Domain.Entities.Identity;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.RoleRepositories;

public interface IRoleRepository
{
    Task<Role> GetAsync(string name);

}