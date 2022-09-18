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
         => new CreatedResult("Object was successfully created", await _coffeeRepository.CreateAsync(coffee));


    public async Task<IActionResult> UpdateAsync(Coffee coffee)
        =>  new OkObjectResult(await _coffeeRepository.UpdateAsync(coffee));

    public async Task<IActionResult> DeleteAsync(Coffee coffee)
        => new OkObjectResult(await _coffeeRepository.DeleteAsync(coffee));
}