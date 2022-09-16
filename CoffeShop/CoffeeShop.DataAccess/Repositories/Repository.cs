using CoffeeShop.DataAccess.Common;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess.Repositories;

public abstract class Repository<T> : IRepository<T> where T : class
{
    private readonly CoffeeShopContext _context;
    private DbSet<T> _dbSet;

    public Repository(CoffeeShopContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
        => await _dbSet.ToListAsync();

    public async Task<string> CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return MessageCreator.SuccessfulCreateMessage<T>();
    }

    public async Task<string> UpdateAsync(T entity)
    {
        _dbSet.UpdateRange(entity);
        await _context.SaveChangesAsync();
        return MessageCreator.SuccessfulUpdateMessage<T>();
    }

    public async Task<string> DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
        return MessageCreator.SuccessfulDeleteMessage<T>();
    }
}