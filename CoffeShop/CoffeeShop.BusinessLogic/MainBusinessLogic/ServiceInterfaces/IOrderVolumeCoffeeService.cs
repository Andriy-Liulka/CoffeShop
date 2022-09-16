using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IOrderVolumeCoffeeService
{
    Task<IActionResult> GetAllAsync();
    Task<IActionResult> GetAsync(int id);
    Task<IActionResult> CreateAsync(OrderVolumeCoffee orderVolumeCoffee);
    Task<IActionResult> UpdateAsync(OrderVolumeCoffee orderVolumeCoffee);
    Task<IActionResult> DeleteAsync(OrderVolumeCoffee orderVolumeCoffee);
}