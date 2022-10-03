using CoffeeShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetAsync(string login);
    Task<string> CreateAsync(User user);
    Task<string> UpdateAsync(User user);
    Task<string> DeleteAsync(User user);
}