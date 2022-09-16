namespace CoffeeShop.DataAccess.Repositories;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<string> CreateAsync(T discount);
    Task<string> UpdateAsync(T discount);
    Task<string> DeleteAsync(T discount);
}