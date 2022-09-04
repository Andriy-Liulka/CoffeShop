using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.VolumeRepositories;

public class VolumeRepository : IVolumeRepository
{
    private readonly CoffeeShopContext _context;
    public VolumeRepository(CoffeeShopContext context)
    {
        _context = context;
    }

    public async Task<Volume> GetAsync(int id)
        => await _context.Volumes.FirstOrDefaultAsync(x=>x.Id.Equals(id)) 
           ?? throw new NullReferenceException();
}