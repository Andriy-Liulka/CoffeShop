using CoffeeShop.Domain.Entities;

namespace CoffeeShop.BusinessLogic.MainBusinessLogic;

public interface ICoffeeService
{
    Task<List<Coffee>> GetAll();
}