using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface ICoffeeService
{
    Task<IActionResult> GetAllAsync();
    Task<IActionResult> GetAsync(int id);
    Task<IActionResult> CreateAsync(Coffee coffee);
    Task<IActionResult> UpdateAsync(Coffee coffee);
    Task<IActionResult> DeleteAsync(Coffee coffee);
}