using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IBonusCoffeeService
{
    Task<IEnumerable<BonusCoffee>> GetAllAsync();
    Task<BonusCoffee> GetAsync(int id);
    Task<string> CreateAsync(BonusCoffee bonusCoffee);
    Task<string> UpdateAsync(BonusCoffee bonusCoffee);
    Task<string> DeleteAsync(BonusCoffee bonusCoffee);
}