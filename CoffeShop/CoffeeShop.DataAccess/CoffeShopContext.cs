
using CoffeeShop.DataAccess.Configurations;
using CoffeeShop.DataAccess.EntityConfigurations;
using CoffeeShop.DataAccess.EntityConfigurations.IdentityConfigurations;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess;

public class CoffeShopContext : DbContext
{
    public CoffeShopContext(DbContextOptions<CoffeShopContext> options) :base(options){ }
    
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    
    public virtual DbSet<Coffee> Coffees { get; set; }
    public virtual DbSet<Discount> Discounts { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<Volume> Volumes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Configure<RoleConfiguration>();
        modelBuilder.Entity<Role>().Configure<UserConfiguration>();
        
        modelBuilder.Entity<Coffee>().Configure<CofeeConfiguration>();
        modelBuilder.Entity<Discount>().Configure<DiscountConfiguration>();
        modelBuilder.Entity<Order>().Configure<OrderConfiguration>();
        modelBuilder.Entity<Volume>().Configure<VolumeConfiguration>();
        
        base.OnModelCreating(modelBuilder);
    }
}