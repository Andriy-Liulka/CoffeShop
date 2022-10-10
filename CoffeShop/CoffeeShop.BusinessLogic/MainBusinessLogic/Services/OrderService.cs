using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.BusinessLogic.Validation;
using CoffeeShop.BusinessLogic.Validation.Validators;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.OrderRepositories;
using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly MainValidator _validator;

    public OrderService(IOrderRepository orderRepository,MainValidator validator)
    {
        _orderRepository = orderRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
        => await _orderRepository.GetAllAsync();

    public async Task<Order> GetAsync(int id)
        => await _orderRepository.GetAsync(id);

    public async Task<string> CreateAsync(Order order)
    {
        _validator.Validate<Order, OrderValidator>(order);
        return await _orderRepository.CreateAsync(order);
    }

    public async Task<string> UpdateAsync(Order order)
    {
        _validator.Validate<Order, OrderValidator>(order);
        return await _orderRepository.UpdateAsync(order);
    }

    public async Task<string> DeleteAsync(Order order)
    {
        _validator.Validate<Order, OrderValidator>(order);
        return await _orderRepository.DeleteAsync(order);
    }
}