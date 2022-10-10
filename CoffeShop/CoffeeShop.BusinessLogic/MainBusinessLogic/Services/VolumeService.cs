using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.BusinessLogic.Validation;
using CoffeeShop.BusinessLogic.Validation.Validators;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.VolumeRepositories;
using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services;

public class VolumeService : IVolumeService
{
    private readonly IVolumeRepository _orderRepository;
    private readonly MainValidator _validator;

    public VolumeService(IVolumeRepository orderRepository,MainValidator validator)
    {
        _orderRepository = orderRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<Volume>> GetAllAsync()
        => await _orderRepository.GetAllAsync();

    public async Task<Volume> GetAsync(int id)
        => await _orderRepository.GetAsync(id);

    public async Task<string> CreateAsync(Volume volume)
    {
        _validator.Validate<Volume, VolumeValidator>(volume);
        return await _orderRepository.CreateAsync(volume);
    }

    public async Task<string> UpdateAsync(Volume volume)
    {
        _validator.Validate<Volume, VolumeValidator>(volume);
        return await _orderRepository.UpdateAsync(volume);
    }

    public async Task<string> DeleteAsync(Volume volume)
    {
        _validator.Validate<Volume, VolumeValidator>(volume);
        return await _orderRepository.DeleteAsync(volume);
    }
}