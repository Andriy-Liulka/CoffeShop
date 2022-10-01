using CoffeeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.DiscountRepositories;

public class DiscountRepository : Repository<Discount>, IDiscountRepository
{

    public DiscountRepository(CoffeeShopContext context) : base(context) { }

    public async Task<Discount> GetAsync(int id)
        => await _context.Discounts.FirstOrDefaultAsync(x => x.Id.Equals(id)) 
           ?? throw new NullReferenceException();
}