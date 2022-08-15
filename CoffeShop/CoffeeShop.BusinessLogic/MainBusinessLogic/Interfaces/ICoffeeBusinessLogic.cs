using CoffeeShop.Domain.Entities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic;

public interface ICoffeeBusinessLogic
{
    Task<List<Coffee>> GetAll();
}