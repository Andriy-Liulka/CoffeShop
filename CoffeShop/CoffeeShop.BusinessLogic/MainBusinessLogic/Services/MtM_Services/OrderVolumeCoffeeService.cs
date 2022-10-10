using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.BusinessLogic.Validation;
using CoffeeShop.BusinessLogic.Validation.Validators;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.OrderVolumeCoffeeRepositories;
using CoffeeShop.Domain.Entities.Identity;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.MtM_Services;

public class OrderVolumeCoffeeService : IOrderVolumeCoffeeService
{
    private readonly IOrderVolumeCoffeeRepository _orderVolumeCoffeeRepository;
    private readonly MainValidator _validator;

    public OrderVolumeCoffeeService(IOrderVolumeCoffeeRepository orderVolumeCoffeeRepository,MainValidator validator)
    {
        _orderVolumeCoffeeRepository = orderVolumeCoffeeRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<OrderVolumeCoffee>> GetAllAsync()
        => await _orderVolumeCoffeeRepository.GetAllAsync();

    public async Task<OrderVolumeCoffee?> GetAsync(int id)
        => await _orderVolumeCoffeeRepository.GetAsync(id);

    public async Task<string> CreateAsync(OrderVolumeCoffee orderVolumeCoffee)
    {
        _validator.Validate<OrderVolumeCoffee, OrderVolumeCoffeeValidator>(orderVolumeCoffee);
        return await _orderVolumeCoffeeRepository.CreateAsync(orderVolumeCoffee);
    }

    public async Task<string> UpdateAsync(OrderVolumeCoffee orderVolumeCoffee)
    {
        _validator.Validate<OrderVolumeCoffee, OrderVolumeCoffeeValidator>(orderVolumeCoffee);
        return  await _orderVolumeCoffeeRepository.UpdateAsync(orderVolumeCoffee);
    }

    public async Task<string> DeleteAsync(OrderVolumeCoffee orderVolumeCoffee)
    {
        _validator.Validate<OrderVolumeCoffee, OrderVolumeCoffeeValidator>(orderVolumeCoffee);
        return await _orderVolumeCoffeeRepository.DeleteAsync(orderVolumeCoffee);
    }
}