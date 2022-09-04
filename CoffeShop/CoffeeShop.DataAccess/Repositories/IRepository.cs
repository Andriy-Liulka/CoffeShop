namespace CoffeeShop.DataAccess.Repositories;

public interface IRepository<T> where T:class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task CreateAsync(T discount);
    Task UpdateAsync(T discount);
    Task DeleteAsync(T discount);
    
}