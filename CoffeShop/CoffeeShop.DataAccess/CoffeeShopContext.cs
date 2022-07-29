
using CoffeeShop.DataAccess.Configurations;
using CoffeeShop.DataAccess.EntityConfigurations;
using CoffeeShop.DataAccess.EntityConfigurations.IdentityConfigurations;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess;

public class CoffeeShopContext : DbContext
{
    public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options) :base(options){ }
    
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
        modelBuilder.Entity<User>().Configure<UserConfiguration,User>();
        modelBuilder.Entity<Role>().Configure<RoleConfiguration,Role>();
        
        modelBuilder.Entity<Coffee>().Configure<CoffeeConfiguration,Coffee>();
        modelBuilder.Entity<Discount>().Configure<DiscountConfiguration,Discount>();
        modelBuilder.Entity<Order>().Configure<OrderConfiguration,Order>();
        modelBuilder.Entity<Volume>().Configure<VolumeConfiguration,Volume>();
        modelBuilder.Entity<BonusCoffee>().Configure<BonusCoffeeConfiguration,BonusCoffee>();

        base.OnModelCreating(modelBuilder);
    }
}