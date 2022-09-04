using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess;
using CoffeeShop.DataAccess.Repositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.OrderRepositories;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services;

public class OrderService : IOrderService
{
    private readonly IRepository<Order> _repository;
    private readonly IOrderRepository _orderRepository;

    public OrderService(IRepository<Order> repository,IOrderRepository orderRepository)
    {
        _repository = repository;
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<Order>> GetAllAsync() 
        => await _repository.GetAllAsync();

    public async Task<Order?> GetAsync(int id) 
        => await _orderRepository.GetAsync(id);

       public async Task CreateAsync(Order order)
           => await _repository.CreateAsync(order);

       public async Task UpdateAsync(Order order)
           => await _repository.UpdateAsync(order);

       public async Task DeleteAsync(Order order)
           => await _repository.DeleteAsync(order);
}