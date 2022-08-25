using CoffeeShop.DataAccess;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic;

public class BonusCoffeeService
{
    private readonly CoffeeShopContext _context;

    public BonusCoffeeService(CoffeeShopContext context)
    {   
        _context = context;
    }
}