using CoffeeShop.Domain.Entities.Identity;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.UserRepositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetAsync(string login);
    Task<User?> GetFullAsync(string login);
}