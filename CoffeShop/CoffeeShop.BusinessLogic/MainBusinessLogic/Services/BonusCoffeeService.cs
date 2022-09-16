using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.BonusCoffeeRepositories;
using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services;

public class BonusCoffeeService : IBonusCoffeeService
{
    private readonly IBonusCoffeeRepository _bonusCoffeeRepository;

    public BonusCoffeeService(IBonusCoffeeRepository bonusCoffeeRepository)
    {
        _bonusCoffeeRepository = bonusCoffeeRepository;
    }

    public async Task<IActionResult> GetAllAsync()
        => new OkObjectResult(await _bonusCoffeeRepository.GetAllAsync());

    public async Task<IActionResult> GetAsync(int id)
        => new OkObjectResult(await _bonusCoffeeRepository.GetAsync(id));

    public async Task<IActionResult> CreateAsync(BonusCoffee bonusCoffee)
        => new OkObjectResult(await _bonusCoffeeRepository.CreateAsync(bonusCoffee));

    public async Task<IActionResult> UpdateAsync(BonusCoffee bonusCoffee)
        => new OkObjectResult(await _bonusCoffeeRepository.UpdateAsync(bonusCoffee));

    public async Task<IActionResult> DeleteAsync(BonusCoffee bonusCoffee)
        => new OkObjectResult(await _bonusCoffeeRepository.DeleteAsync(bonusCoffee));
}