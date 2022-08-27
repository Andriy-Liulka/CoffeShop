using CoffeeShop.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CoffeShop.Api.Configurations.Middlewares;

public static class DatabaseConfigurator
{
    internal static IApplicationBuilder UpdateDatabase(this IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices
                   .GetRequiredService<IServiceScopeFactory>()
                   .CreateScope())
        {
            using (var context = serviceScope.ServiceProvider.GetService<CoffeeShopContext>())
            {
                context?.Database.Migrate();
            }
        }
        return app;
    }
}