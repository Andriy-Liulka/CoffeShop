using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.VolumeRepositories;
using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services;

public class VolumeService : IVolumeService
{
    private readonly IVolumeRepository _orderRepository;

    public VolumeService(IVolumeRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IActionResult> GetAllAsync()
        => new OkObjectResult(await _orderRepository.GetAllAsync());

    public async Task<IActionResult> GetAsync(int id)
        => new OkObjectResult(await _orderRepository.GetAsync(id));

    public async Task<IActionResult> CreateAsync(Volume volume)
        => new OkObjectResult(await _orderRepository.CreateAsync(volume));

    public async Task<IActionResult> UpdateAsync(Volume volume)
        => new OkObjectResult(await _orderRepository.UpdateAsync(volume));

    public async Task<IActionResult> DeleteAsync(Volume volume)
        => new OkObjectResult(await _orderRepository.DeleteAsync(volume));
}