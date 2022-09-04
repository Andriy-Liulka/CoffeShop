using CoffeeShop.Domain.Entities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IDiscountService
{
    Task<IEnumerable<Discount>> GetAllAsync();
    Task<Discount?> GetAsync(int id);
    Task CreateAsync(Discount discount);
    Task UpdateAsync(Discount discount);
    Task DeleteAsync(Discount discount);
}