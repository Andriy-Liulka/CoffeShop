using CoffeeShop.BusinessLogic.Dto;
using CoffeeShop.DataAccess.Repositories;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IDiscountCoffeeService
{
    public Task<IActionResult> GetAllAsync();
    public Task<IActionResult> GetAsync(DiscountCoffeeGetAsyncDto key);
    public Task<IActionResult> CreateAsync(DiscountCoffee discountCoffee);
    public Task<IActionResult> UpdateAsync(DiscountCoffee discountCoffee);
    public Task<IActionResult> DeleteAsync(DiscountCoffee discountCoffee);
}