using CoffeeShop.BusinessLogic.Dto;
using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.DiscountCoffeeRepositories;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.MtM_Services;

public class DiscountCoffeeService : IDiscountCoffeeService
{
    private readonly IDiscountCoffeeRepository _discountCoffeeRepository;

    public DiscountCoffeeService(IDiscountCoffeeRepository discountCoffeeRepository)
    {
        _discountCoffeeRepository = discountCoffeeRepository;
    }

    public async Task<IActionResult> GetAllAsync()
        => new OkObjectResult(await _discountCoffeeRepository.GetAllAsync());

    public async Task<IActionResult> GetAsync(DiscountCoffeeGetAsyncDto key)
        => new OkObjectResult(await _discountCoffeeRepository.GetAsync(key.CoffeeId, key.DiscountId));

    public async Task<IActionResult> CreateAsync(DiscountCoffee discountCoffee)
        => new OkObjectResult(await _discountCoffeeRepository.CreateAsync(discountCoffee));

    public async Task<IActionResult> UpdateAsync(DiscountCoffee discountCoffee)
        => new OkObjectResult(await _discountCoffeeRepository.UpdateAsync(discountCoffee));

    public async Task<IActionResult> DeleteAsync(DiscountCoffee discountCoffee)
        => new OkObjectResult(await _discountCoffeeRepository.DeleteAsync(discountCoffee));
}