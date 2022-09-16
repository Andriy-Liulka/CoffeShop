using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IVolumeService
{
    Task<IActionResult> GetAllAsync() ;
    Task<IActionResult> GetAsync(int id);
    Task<IActionResult> CreateAsync(Volume volume);
    Task<IActionResult> UpdateAsync(Volume volume);
    Task<IActionResult> DeleteAsync(Volume volume);
}