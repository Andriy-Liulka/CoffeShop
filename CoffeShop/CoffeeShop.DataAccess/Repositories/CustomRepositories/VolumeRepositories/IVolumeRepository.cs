using CoffeeShop.Domain.Entities;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.VolumeRepositories;

public interface IVolumeRepository
{
    Task<Volume> GetAsync(int id);
}