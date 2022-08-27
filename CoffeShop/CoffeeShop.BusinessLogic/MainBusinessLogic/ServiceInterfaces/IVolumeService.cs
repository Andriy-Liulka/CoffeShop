using CoffeeShop.Domain.Entities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IVolumeService
{
    public Task<List<Volume>> GetAllAsync() ;

    public Task<Volume?> GetAsync(int id);
    
    public Task CreateAsync(Volume volume);

    public Task UpdateAsync(Volume volume);

    public Task DeleteAsync(Volume volume);
}