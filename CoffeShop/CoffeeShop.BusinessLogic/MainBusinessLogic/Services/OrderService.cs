using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.OrderRepositories;
using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
        => await _orderRepository.GetAllAsync();

    public async Task<Order> GetAsync(int id)
        => await _orderRepository.GetAsync(id);

    public async Task<string> CreateAsync(Order order)
        => await _orderRepository.CreateAsync(order);

    public async Task<string> UpdateAsync(Order order)
        => await _orderRepository.UpdateAsync(order);

    public async Task<string> DeleteAsync(Order order)
        => await _orderRepository.DeleteAsync(order);
}