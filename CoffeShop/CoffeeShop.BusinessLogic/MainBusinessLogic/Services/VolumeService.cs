using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess;
using CoffeeShop.DataAccess.Repositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.VolumeRepositories;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Volume?> GetAsync(int id)
        => await _orderRepository.GetAsync(id);

    public async Task CreateAsync(Volume volume)
        => await _orderRepository.CreateAsync(volume);

    public async Task UpdateAsync(Volume volume)
        => await _orderRepository.UpdateAsync(volume);

    public async Task DeleteAsync(Volume volume)
        => await _orderRepository.DeleteAsync(volume);
}