using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IOrderVolumeCoffeeService
{
    Task<IEnumerable<OrderVolumeCoffee>> GetAllAsync();
    Task<OrderVolumeCoffee?> GetAsync(int id);
    Task<string> CreateAsync(OrderVolumeCoffee orderVolumeCoffee);
    Task<string> UpdateAsync(OrderVolumeCoffee orderVolumeCoffee);
    Task<string> DeleteAsync(OrderVolumeCoffee orderVolumeCoffee);
}