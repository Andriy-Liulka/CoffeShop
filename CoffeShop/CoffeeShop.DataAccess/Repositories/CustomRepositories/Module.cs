using CoffeeShop.DataAccess.Repositories.CustomRepositories.BonusCoffeeRepositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.CoffeeRepositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.DiscountCoffeeRepositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.DiscountRepositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.IdentityCredentialRepositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.OrderRepositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.OrderVolumeCoffeeRepositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.RoleRepositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.UserRepositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories.VolumeRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeShop.DataAccess.Repositories.CustomRepositories;

public static class Module
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
    {
        services.AddScoped<IIdentityCredentialRepository,IdentityCredentialRepository>();
        services.AddScoped<IBonusCoffeeRepository,BonusCoffeeRepository>();
        services.AddScoped<ICoffeeRepository,CoffeeRepository>();
        services.AddScoped<IDiscountCoffeeRepository,DiscountCoffeeRepository>();
        services.AddScoped<IDiscountRepository,DiscountRepository>();
        services.AddScoped<IOrderRepository,OrderRepository>();
        services.AddScoped<IOrderVolumeCoffeeRepository, OrderVolumeCoffeeRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IVolumeRepository, VolumeRepository>();
        return services;
    }
}