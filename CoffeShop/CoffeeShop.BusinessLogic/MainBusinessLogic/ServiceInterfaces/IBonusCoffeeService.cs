using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IBonusCoffeeService
{
    Task<IActionResult> GetAllAsync();
    Task<IActionResult> GetAsync(int id);
    Task<IActionResult> CreateAsync(BonusCoffee bonusCoffee);
    Task<IActionResult> UpdateAsync(BonusCoffee bonusCoffee);
    Task<IActionResult> DeleteAsync(BonusCoffee bonusCoffee);
}