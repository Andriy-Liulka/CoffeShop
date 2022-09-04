using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess;
using CoffeeShop.DataAccess.Repositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.OrderVolumeCoffeeRepositories;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.MtM_Services;

public class OrderVolumeCoffeeService : IOrderVolumeCoffeeService
{
    private readonly IRepository<OrderVolumeCoffee> _repository;
    private readonly IOrderVolumeCoffeeRepository _orderVolumeCoffeeRepository;

    public OrderVolumeCoffeeService(IRepository<OrderVolumeCoffee> repository,IOrderVolumeCoffeeRepository orderVolumeCoffeeRepository)
    {
        _repository = repository;
        _orderVolumeCoffeeRepository = orderVolumeCoffeeRepository;
    }

    public async Task<IEnumerable<OrderVolumeCoffee>> GetAllAsync()
        => await _repository.GetAllAsync(); 

    public async Task<OrderVolumeCoffee?> GetAsync(int id) 
        => await _orderVolumeCoffeeRepository.GetAsync(id);

    public async Task CreateAsync(OrderVolumeCoffee orderVolumeCoffee)
        => await _repository.CreateAsync(orderVolumeCoffee);

    public async Task UpdateAsync(OrderVolumeCoffee orderVolumeCoffee)
        => await _repository.UpdateAsync(orderVolumeCoffee);

    public async Task DeleteAsync(OrderVolumeCoffee orderVolumeCoffee)
        => await _repository.DeleteAsync(orderVolumeCoffee);
}