using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.CoffeeRepositories;
using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services;

public class CoffeeService : ICoffeeService
{
    private readonly ICoffeeRepository _coffeeRepository;

    public CoffeeService(ICoffeeRepository coffeeRepository)
    {
        _coffeeRepository = coffeeRepository;
    }

    public async Task<IActionResult> GetAllAsync()
        => new OkObjectResult(await _coffeeRepository.GetAllAsync());


    public async Task<IActionResult> GetAsync(int id)
        => new OkObjectResult(await _coffeeRepository.GetAsync(id));

    public async Task<IActionResult> CreateAsync(Coffee coffee)
    {
        await _coffeeRepository.CreateAsync(coffee);
        return new CreatedResult("Object was successfully created", coffee);
    }

    public async Task<IActionResult> UpdateAsync(Coffee coffee)
    {
        await _coffeeRepository.UpdateAsync(coffee);
        return new OkResult();
    }

    public async Task<IActionResult> DeleteAsync(Coffee coffee)
    {
        await _coffeeRepository.DeleteAsync(coffee);
        return new OkResult();
    }
}