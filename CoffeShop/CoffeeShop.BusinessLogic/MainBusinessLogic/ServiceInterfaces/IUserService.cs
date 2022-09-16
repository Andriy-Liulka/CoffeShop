using CoffeeShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IUserService
{
    Task<IActionResult> GetAllAsync();
    Task<IActionResult> GetAsync(string login);
    Task<IActionResult> CreateAsync(User user);
    Task<IActionResult> UpdateAsync(User user);
    Task<IActionResult> DeleteAsync(User user);
}