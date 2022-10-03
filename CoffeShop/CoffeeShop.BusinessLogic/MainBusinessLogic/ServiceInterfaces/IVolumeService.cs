using CoffeeShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IVolumeService
{
    Task<IEnumerable<Volume>> GetAllAsync();
    Task<Volume> GetAsync(int id);
    Task<string> CreateAsync(Volume volume);
    Task<string> UpdateAsync(Volume volume);
    Task<string> DeleteAsync(Volume volume);
}