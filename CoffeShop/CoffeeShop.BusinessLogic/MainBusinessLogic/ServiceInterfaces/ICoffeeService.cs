using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface ICoffeeService
{
    Task<IEnumerable<Coffee>> GetAllAsync();
    Task<Coffee> GetAsync(int id);
    Task<string> CreateAsync(Coffee coffee);
    Task<string> UpdateAsync(Coffee coffee);
    Task<string> DeleteAsync(Coffee coffee);
}