using CoffeeShop.DataAccess.Repositories;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;

public interface IDiscountCoffeeService : IRepository<DiscountCoffee>
{
    Task<DiscountCoffee?> GetAsync(int discountId, int coffeetId);
}