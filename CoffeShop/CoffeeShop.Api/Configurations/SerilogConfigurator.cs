using Serilog;
using Serilog.Events;

namespace CoffeShop.Api.Configurations;

public static class SerilogConfigurator
{
    public static void ConfigureSerilog(HostBuilderContext hostContext, IServiceProvider serviceProvider, LoggerConfiguration configuration)
    {
        configuration
            .MinimumLevel.Information()
            .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
            .WriteTo.File("log.txt",shared:true);
    }
}