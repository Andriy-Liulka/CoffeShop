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

    public async Task<IActionResult> GetAllAsync()
        => new OkObjectResult(await _orderRepository.GetAllAsync());

    public async Task<IActionResult> GetAsync(int id)
        => new OkObjectResult(await _orderRepository.GetAsync(id));

    public async Task<IActionResult> CreateAsync(Order order)
        => new OkObjectResult(await _orderRepository.CreateAsync(order));

    public async Task<IActionResult> UpdateAsync(Order order)
        => new OkObjectResult(await _orderRepository.UpdateAsync(order));

    public async Task<IActionResult> DeleteAsync(Order order)
        => new OkObjectResult(await _orderRepository.DeleteAsync(order));
}