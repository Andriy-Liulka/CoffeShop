
using CoffeeShop.DataAccess.Configurations;
using CoffeeShop.DataAccess.EntityConfigurations;
using CoffeeShop.DataAccess.EntityConfigurations.IdentityConfigurations;
using CoffeeShop.DataAccess.EntityConfigurations.MtM_IntermediateEntitiesConfigurations;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Entities.Identity;
using CoffeeShop.Domain.Entities.MtM_IntermediateEntities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DataAccess;

public class CoffeeShopContext : DbContext
{
    public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options) :base(options){ }
    public CoffeeShopContext(){}
    
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    
    public virtual DbSet<Coffee> Coffees { get; set; }
    public virtual DbSet<Discount> Discounts { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<Volume> Volumes { get; set; }
    public virtual DbSet<BonusCoffee> BonusCoffees { get; set; }
    
    public virtual DbSet<BonusCoffee> DiscBonusCoffees { get; set; }
    public virtual DbSet<OrderVolumeCoffee> OrderVolumeCoffees { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Configure<UserConfiguration,User>();
        modelBuilder.Entity<Role>().Configure<RoleConfiguration,Role>().SetDefaultData<RoleConfiguration,Role>();
        
        modelBuilder.Entity<Coffee>().Configure<CoffeeConfiguration,Coffee>().SetDefaultData<CoffeeConfiguration,Coffee>();
        modelBuilder.Entity<Discount>().Configure<DiscountConfiguration,Discount>().SetDefaultData<DiscountConfiguration,Discount>();
        modelBuilder.Entity<Order>().Configure<OrderConfiguration,Order>();
        modelBuilder.Entity<Volume>().Configure<VolumeConfiguration,Volume>().SetDefaultData<VolumeConfiguration,Volume>();
        modelBuilder.Entity<BonusCoffee>().Configure<BonusCoffeeConfiguration,BonusCoffee>().SetDefaultData<BonusCoffeeConfiguration,BonusCoffee>();
        
        modelBuilder.Entity<DiscountCoffee>().Configure<DiscountCoffeeConfiguration,DiscountCoffee>().SetDefaultData<DiscountCoffeeConfiguration,DiscountCoffee>();
        modelBuilder.Entity<OrderVolumeCoffee>().Configure<OrderVolumeCoffeeConfiguration,OrderVolumeCoffee>();

        base.OnModelCreating(modelBuilder);
    }
}