using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.OrderVolumeCoffeeRepositories;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.AspNetCore.Mvc;

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

    public async Task<string> CreateAsync(OrderVolumeCoffee orderVolumeCoffee)
        => await _orderVolumeCoffeeRepository.CreateAsync(orderVolumeCoffee);

    public async Task<string> UpdateAsync(OrderVolumeCoffee orderVolumeCoffee)
        => await _orderVolumeCoffeeRepository.UpdateAsync(orderVolumeCoffee);

    public async Task<string> DeleteAsync(OrderVolumeCoffee orderVolumeCoffee)
        => await _orderVolumeCoffeeRepository.DeleteAsync(orderVolumeCoffee);
}