using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IDiscountService
{
    Task<IActionResult> GetAllAsync();
    Task<IActionResult> GetAsync(int id);
    Task<IActionResult> CreateAsync(Discount discount);
    Task<IActionResult> UpdateAsync(Discount discount);
    Task<IActionResult> DeleteAsync(Discount discount);
}