using CoffeeShop.BusinessLogic.Dto;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IDiscountCoffeeService
{
    public Task<IEnumerable<DiscountCoffee>> GetAllAsync();
    public Task<DiscountCoffee> GetAsync(int coffeeId, int discountId);
    public Task<string> CreateAsync(DiscountCoffee discountCoffee);
    public Task<string> UpdateAsync(DiscountCoffee discountCoffee);
    public Task<string> DeleteAsync(DiscountCoffee discountCoffee);
}