using CoffeeShop.Domain.Entities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IVolumeService
{
    Task<IEnumerable<Volume>> GetAllAsync() ;

    Task<Volume?> GetAsync(int id);
    
    Task CreateAsync(Volume volume);

    Task UpdateAsync(Volume volume);

    Task DeleteAsync(Volume volume);
}