using System.Text;
using System.Text.Json.Serialization;
using CoffeeShop.BusinessLogic;
using CoffeeShop.DataAccess;
using CoffeeShop.DataAccess.Repositories.CustomRepositories;
using CoffeShop.Api.Authentication;
using CoffeShop.Api.Common;
using CoffeShop.Api.Configurations;
using CoffeShop.Api.Configurations.Middlewares;
using CoffeShop.Api.Controllers.Identity.Authorization;
using CoffeShop.Api.Controllers.Identity.Authorization.Policies;
using CoffeShop.Api.ProxyExceptionHandlingLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;

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
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Coffee Shop", Version = "v1" });
            var securityDefinitionId = "JwtAuth";
            var securityDefinition = new OpenApiSecurityScheme
            {
                Description = "Jwt access tokens",
                Name = securityDefinitionId,
                In = ParameterLocation.Header,
                Scheme = "Bearer",
                Type = SecuritySchemeType.Http
            };
            var securityScheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = securityDefinitionId,
                    Type = ReferenceType.SecurityScheme
                }
            };
            var securityRequirements = new OpenApiSecurityRequirement
            {
                { securityScheme, new string[] { } }
            };
            c.AddSecurityDefinition(securityDefinitionId, securityDefinition);
            c.AddSecurityRequirement(securityRequirements);
        });
        services.AddDbContext<CoffeeShopContext>(option =>
        {
            option.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")
                                ?? throw new ArgumentNullException("ConnectionString",
                                    Translation.EmptyStringMessage));
        });

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidAudience = Configuration["JWT:Issuer"],
                    ValidIssuer = Configuration["JWT:Audience"],
                    ClockSkew = TimeSpan.Zero,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

        services.AddHealthChecks();

        services.AddCustomServices(services.AddDataAccessServices, services.AddBusinessLogicServices);

        services.AddAutoMapper(typeof(AppMappingProfile));

        services.AddScoped(typeof(IProxyExceptionHandler<>), typeof(ProxyExceptionHandler<>));

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<IUserIdentityProfileProvider, UserIdentityProfileProvider>();
        
        services.AddSingleton<IAuthorizationHandler, PermissionRequirementHandler>();
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
        services.AddSingleton<IPolicyResolver, PolicyResolver>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        //app.UpdateDatabase();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Coffee Shop v1"));
        }

        app.UseSerilogRequestLogging();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseMiddleware<ErrorHandlerMiddleware>();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute("default", "api/{controller}/{action}");
            endpoints.MapHealthChecks("/health", new HealthCheckOptions
            {
                ResultStatusCodes =
                {
                    [HealthStatus.Healthy] = StatusCodes.Status200OK,
                    [HealthStatus.Unhealthy] = StatusCodes.Status500InternalServerError
                }
            });
        });
    }
}