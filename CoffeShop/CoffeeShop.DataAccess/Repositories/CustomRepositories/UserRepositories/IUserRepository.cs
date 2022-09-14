using CoffeeShop.Domain.Entities.Identity;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.UserRepositories;

public interface IUserRepository
{
    Task<User?> GetAsync(string login);
    Task<User?> GetFullAsync(string login);
}