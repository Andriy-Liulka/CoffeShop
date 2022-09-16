using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.DiscountRepositories;
using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services;

public class DiscountService : IDiscountService
{
    private readonly IDiscountRepository _discountRepository;

    public DiscountService(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }

    public async Task<IActionResult> GetAllAsync()
        => new OkObjectResult(await _discountRepository.GetAllAsync());

    public async Task<IActionResult> GetAsync(int id)
        => new OkObjectResult(await _discountRepository.GetAsync(id));

    public async Task<IActionResult> CreateAsync(Discount discount)
        => new OkObjectResult(await _discountRepository.CreateAsync(discount));

    public async Task<IActionResult> UpdateAsync(Discount discount)
        => new OkObjectResult(await _discountRepository.UpdateAsync(discount));

    public async Task<IActionResult> DeleteAsync(Discount discount)
        => new OkObjectResult(await _discountRepository.DeleteAsync(discount));
}