using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IDiscountService
{
    Task<IEnumerable<Discount>> GetAllAsync();
    Task<Discount> GetAsync(int id);
    Task<string> CreateAsync(Discount discount);
    Task<string> UpdateAsync(Discount discount);
    Task<string> DeleteAsync(Discount discount);
}