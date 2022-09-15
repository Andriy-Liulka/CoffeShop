using CoffeeShop.Domain.Entities;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.VolumeRepositories;

public interface IVolumeRepository : IRepository<Volume>
{
    Task<Volume> GetAsync(int id);
}