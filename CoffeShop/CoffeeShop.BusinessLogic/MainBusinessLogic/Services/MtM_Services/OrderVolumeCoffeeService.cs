using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess;
using CoffeeShop.DataAccess.Repositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.OrderVolumeCoffeeRepositories;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.MtM_Services;

public class OrderVolumeCoffeeService : IOrderVolumeCoffeeService
{
    private readonly IOrderVolumeCoffeeRepository _orderVolumeCoffeeRepository;

    public OrderVolumeCoffeeService(IOrderVolumeCoffeeRepository orderVolumeCoffeeRepository)
    {
        _orderVolumeCoffeeRepository = orderVolumeCoffeeRepository;
    }

    public async Task<IEnumerable<OrderVolumeCoffee>> GetAllAsync()
        => await _orderVolumeCoffeeRepository.GetAllAsync(); 

    public async Task<OrderVolumeCoffee?> GetAsync(int id) 
        => await _orderVolumeCoffeeRepository.GetAsync(id);

    public async Task CreateAsync(OrderVolumeCoffee orderVolumeCoffee)
        => await _orderVolumeCoffeeRepository.CreateAsync(orderVolumeCoffee);

    public async Task UpdateAsync(OrderVolumeCoffee orderVolumeCoffee)
        => await _orderVolumeCoffeeRepository.UpdateAsync(orderVolumeCoffee);

    public async Task DeleteAsync(OrderVolumeCoffee orderVolumeCoffee)
        => await _orderVolumeCoffeeRepository.DeleteAsync(orderVolumeCoffee);
}