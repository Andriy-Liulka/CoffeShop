
using System.Text.Json.Serialization;
using CoffeeShop.BusinessLogic.MainBusinessLogic.ServiceInterfaces;
using CoffeeShop.BusinessLogic.MainBusinessLogic.Services;
using CoffeeShop.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace CoffeShop.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging();
        services.AddControllers()
            .AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo {Title = "Coffee Shop", Version = "v1"});
        });
        services.AddDbContext<CoffeeShopContext>(option =>
        {
            option.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString") ?? String.Empty);
        });

        services.AddScoped<ICoffeeService, CoffeeService>();
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Coffee Shop v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(name:"default",pattern:"api/{controller}/{action}");
        });
    }
}