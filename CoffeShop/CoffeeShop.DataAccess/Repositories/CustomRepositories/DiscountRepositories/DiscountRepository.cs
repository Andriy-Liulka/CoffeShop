using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.DiscountRepositories;

public class DiscountRepository : Repository<Discount>, IDiscountRepository
{
    private readonly CoffeeShopContext _context;

    public DiscountRepository(CoffeeShopContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Discount> GetAsync(int id)
        => await _context.Discounts.FirstOrDefaultAsync(x => x.Id.Equals(id)) 
           ?? throw new NullReferenceException();
}