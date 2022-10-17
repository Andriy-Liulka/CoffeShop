using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.DiscountCoffeeRepositories;

public class DiscountCoffeeRepository : Repository<DiscountCoffee>, IDiscountCoffeeRepository
{
    public DiscountCoffeeRepository(CoffeeShopContext context) : base(context) { }

    public async Task<DiscountCoffee> GetAsync(long discountId, long coffeetId)
        => await _context.DiscountCoffees.FirstOrDefaultAsync(x => 
            x.DiscountId.Equals(discountId)
            && 
            x.CoffeeId.Equals(coffeetId)) 
           ?? throw new NullReferenceException();
}