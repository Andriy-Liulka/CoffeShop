using CoffeeShop.Domain.Entities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IBonusCoffeeService
{
    Task<List<BonusCoffee>> GetAllAsync();
    Task<BonusCoffee?> GetAsync(int id);
    Task CreateAsync(BonusCoffee bonusCoffee);
    Task UpdateAsync(BonusCoffee bonusCoffee);
    Task DeleteAsync(BonusCoffee bonusCoffee);
}