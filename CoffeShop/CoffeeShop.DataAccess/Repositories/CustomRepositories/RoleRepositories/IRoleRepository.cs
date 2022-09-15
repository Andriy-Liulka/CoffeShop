using CoffeeShop.Domain.Entities.Identity;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.RoleRepositories;

public interface IRoleRepository : IRepository<Role>
{
    Task<Role> GetAsync(string name);

}