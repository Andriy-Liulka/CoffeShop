using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.DataAccess;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services.MtM_Services;

public class OrderVolumeCoffeeService : IOrderVolumeCoffeeService
{
    private readonly CoffeeShopContext _context;
    public OrderVolumeCoffeeService(CoffeeShopContext context)
    {   
        _context = context;
    }
    public async Task<List<OrderVolumeCoffee>> GetAllAsync() => await _context.OrderVolumeCoffees
        .Include(x=>x.Coffee)
        .Include(x=>x.Order)
        .Include(x=>x.Volume)
        .ToListAsync();

    public async Task<OrderVolumeCoffee?> GetAsync(int orderId,int volumeId,int coffeeId) => await _context.OrderVolumeCoffees
        .Include(x=>x.Coffee)
        .Include(x=>x.Order)
        .Include(x=>x.Volume)
        .FirstOrDefaultAsync(x => 
            x.OrderId.Equals(orderId) &&
            x.VolumeId.Equals(volumeId) && 
            x.CoffeetId.Equals(coffeeId));

    public async Task CreateAsync(OrderVolumeCoffee orderVolumeCoffee)
    {
        await _context.OrderVolumeCoffees.AddAsync(orderVolumeCoffee);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(OrderVolumeCoffee orderVolumeCoffee)
    {
        _context.OrderVolumeCoffees.Update(orderVolumeCoffee);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(OrderVolumeCoffee orderVolumeCoffee)
    {
        _context.OrderVolumeCoffees.Remove(orderVolumeCoffee);
        await _context.SaveChangesAsync();
    }
}