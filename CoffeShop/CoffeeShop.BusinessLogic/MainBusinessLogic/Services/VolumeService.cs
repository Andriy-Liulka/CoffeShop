using CoffeeShop.DataAccess;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic;

public class VolumeService
{
    private readonly CoffeeShopContext _context;
    public VolumeService(CoffeeShopContext context)
    {   
        _context = context;
    } 
    public async Task<List<Volume>> GetAllAsync() => await _context.Volumes
        .Include(x=>x.BonusCoffees)
        .ThenInclude(x=>x.Coffee)    
        
        .Include(x=>x.OrderVolumeCoffees)
        .ThenInclude(x=>x.Order)
        
        .ToListAsync();

    public async Task<Volume?> GetAsync(int id) => await _context.Volumes
        .Include(x=>x.BonusCoffees)
        .ThenInclude(x=>x.Coffee)    
        
        .Include(x=>x.OrderVolumeCoffees)
        .ThenInclude(x=>x.Order)
        
        .FirstOrDefaultAsync(x => x.Id.Equals(id));

    public async Task CreateAsync(Volume volume)
    {
        await _context.Volumes.AddAsync(volume);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Volume volume)
    {
        _context.Volumes.Update(volume);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Volume volume)
    {
        _context.Volumes.Remove(volume);
        await _context.SaveChangesAsync();
    }
}