using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IOrderService
{
    Task<IActionResult> GetAllAsync();
    Task<IActionResult> GetAsync(int id);
    Task<IActionResult> CreateAsync(Order order);
    Task<IActionResult> UpdateAsync(Order order);
    Task<IActionResult> DeleteAsync(Order order);
}