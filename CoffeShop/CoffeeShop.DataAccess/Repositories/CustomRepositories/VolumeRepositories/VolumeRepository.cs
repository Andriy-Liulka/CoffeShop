using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.VolumeRepositories;

public class VolumeRepository : Repository<Volume>, IVolumeRepository
{
    public VolumeRepository(CoffeeShopContext context) : base(context) { }

    public async Task<Volume> GetAsync(long id)
        => await _context.Volumes.FirstOrDefaultAsync(x=>x.Id.Equals(id)) 
           ?? throw new NullReferenceException();
}