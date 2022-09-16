namespace CoffeShop.Api;

internal static class ModuleConfigurator
{
    internal static IServiceCollection AddCustomServices(this IServiceCollection services,
        params Func<IServiceCollection>[] configurators)
    {
        configurators.ToList().ForEach(x => x.Invoke());
        return services;
    }
}