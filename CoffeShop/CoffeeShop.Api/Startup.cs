
using System.Text;
using System.Text.Json.Serialization;
using CoffeeShop.BusinessLogic;
using CoffeeShop.DataAccess;
using CoffeeShop.DataAccess.Repositories;
using CoffeeShop.DataAccess.Repositories.CustomRepositories;
using CoffeShop.Api.Configurations.Middlewares;
using CoffeShop.Api.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
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
        services
            .AddControllers()
            .AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo {Title = "Coffee Shop", Version = "v1"});
        });
        services.AddDbContext<CoffeeShopContext>(option =>
            option.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString") 
                                ??
                                throw new ArgumentNullException("ConnectionString","Your connection string is empty")));
        
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("IdentityConnectionString")
                                ??
                                throw new ArgumentNullException("ConnectionString","Your connection string is empty")));
        
        services.AddIdentity<ApplicationSecurityUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero,

                ValidAudience = Configuration["JWT:ValidAudience"],
                ValidIssuer = Configuration["JWT:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
            };
        });

        services.AddHealthChecks();
        
        services.AddEndpointsApiExplorer();

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddCustomServices(services.AddDataAccessServices,services.AddBusinessLogicServices);

        services.AddSingleton<TokensGenerator>();
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UpdateDatabase();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Coffee Shop v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(name:"default",pattern:"api/{controller}/{action}");
            endpoints.MapHealthChecks("/health", new HealthCheckOptions()
            {
                ResultStatusCodes =
                {
                    [HealthStatus.Healthy]=StatusCodes.Status200OK,
                    [HealthStatus.Unhealthy]=StatusCodes.Status500InternalServerError
                }
            });
        });
    }
}