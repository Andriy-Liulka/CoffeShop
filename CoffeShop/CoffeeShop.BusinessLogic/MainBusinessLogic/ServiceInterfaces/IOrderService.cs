using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order> GetAsync(int id);
    Task<string> CreateAsync(Order order);
    Task<string> UpdateAsync(Order order);
    Task<string> DeleteAsync(Order order);
}