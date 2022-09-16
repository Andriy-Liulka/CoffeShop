using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories.DiscountCoffeeRepositories;

public class DiscountCoffeeRepository : Repository<DiscountCoffee>, IDiscountCoffeeRepository
{
    private readonly CoffeeShopContext _context;

    public DiscountCoffeeRepository(CoffeeShopContext context) : base(context)
    {
        _context = context;
    }

    public async Task<DiscountCoffee> GetAsync(int discountId, int coffeetId)
        => await _context.DiscountCoffees.FirstOrDefaultAsync(x => 
            x.DiscountId.Equals(discountId)
            && 
            x.CoffeeId.Equals(coffeetId)) 
           ?? throw new NullReferenceException();
}