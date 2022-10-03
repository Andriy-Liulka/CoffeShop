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

    public async Task<IEnumerable<Volume>> GetAllAsync()
        => await _orderRepository.GetAllAsync();

    public async Task<Volume> GetAsync(int id)
        => await _orderRepository.GetAsync(id);

    public async Task<string> CreateAsync(Volume volume)
        => await _orderRepository.CreateAsync(volume);

    public async Task<string> UpdateAsync(Volume volume)
        => await _orderRepository.UpdateAsync(volume);

    public async Task<string> DeleteAsync(Volume volume)
        => await _orderRepository.DeleteAsync(volume);
}