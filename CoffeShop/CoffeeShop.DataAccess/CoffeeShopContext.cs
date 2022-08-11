﻿
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
        
        modelBuilder.Entity<Discount_Coffee>().Configure<DiscountCoffeeConfiguration,Discount_Coffee>();
        modelBuilder.Entity<Order_Volume_Coffee>().Configure<OrderVolumeCoffeeConfiguration,Order_Volume_Coffee>();

        base.OnModelCreating(modelBuilder);
    }
}