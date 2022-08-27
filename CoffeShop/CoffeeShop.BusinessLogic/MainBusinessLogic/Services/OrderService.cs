using CoffeeShop.DataAccess;
using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.Services;

public class OrderService
{
    
       private readonly CoffeeShopContext _context;
       public OrderService(CoffeeShopContext context)
       {   
           _context = context;
       } 
       public async Task<List<Order>> GetAllAsync() => await _context.Orders
           .Include(x=>x.OrderVolumeCoffees)
           .ThenInclude(x=>x.Coffee)
           
           .Include(x=>x.OrderVolumeCoffees)
           .ThenInclude(x=>x.Order)
           
           .Include(x=>x.OrderVolumeCoffees)
           .ThenInclude(x=>x.Volume)
           
           .ToListAsync();

       public async Task<Order?> GetAsync(int id) => await _context.Orders
           .Include(x=>x.OrderVolumeCoffees)
           .ThenInclude(x=>x.Coffee)
           
           .Include(x=>x.OrderVolumeCoffees)
           .ThenInclude(x=>x.Order)
           
           .Include(x=>x.OrderVolumeCoffees)
           .ThenInclude(x=>x.Volume)

           .FirstOrDefaultAsync(x => x.Id.Equals(id));

       public async Task CreateAsync(Order order)
       {
           await _context.Orders.AddAsync(order);
           await _context.SaveChangesAsync();
       }

       public async Task UpdateAsync(Order order)
       {
           _context.Orders.Update(order);
           await _context.SaveChangesAsync();
       }

       public async Task DeleteAsync(Order order)
       {
           _context.Orders.Remove(order);
           await _context.SaveChangesAsync();
       }
}