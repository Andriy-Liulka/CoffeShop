using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess;
using CoffeeShop.DataAccess.Repositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.OrderVolumeCoffeeRepositories;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.MtM_Services;

public class OrderVolumeCoffeeService : IOrderVolumeCoffeeService
{
    private readonly IOrderVolumeCoffeeRepository _orderVolumeCoffeeRepository;

    public OrderVolumeCoffeeService(IOrderVolumeCoffeeRepository orderVolumeCoffeeRepository)
    {
        _orderVolumeCoffeeRepository = orderVolumeCoffeeRepository;
    }

    public async Task<IActionResult> GetAllAsync()
        => new OkObjectResult(await _orderVolumeCoffeeRepository.GetAllAsync());

    public async Task<IActionResult> GetAsync(int id)
        => new OkObjectResult(await _orderVolumeCoffeeRepository.GetAsync(id));

    public async Task<IActionResult> CreateAsync(OrderVolumeCoffee orderVolumeCoffee)
        => new OkObjectResult(await _orderVolumeCoffeeRepository.CreateAsync(orderVolumeCoffee));

    public async Task<IActionResult> UpdateAsync(OrderVolumeCoffee orderVolumeCoffee)
        => new OkObjectResult(await _orderVolumeCoffeeRepository.UpdateAsync(orderVolumeCoffee));

    public async Task<IActionResult> DeleteAsync(OrderVolumeCoffee orderVolumeCoffee)
        => new OkObjectResult(await _orderVolumeCoffeeRepository.DeleteAsync(orderVolumeCoffee));
}