using Serilog;
using Serilog.Events;

namespace CoffeShop.Api.Configurations;

public static class SerilogConfigurator
{
    public static void ConfigureSerilog(HostBuilderContext hostContext, IServiceProvider serviceProvider,
        LoggerConfiguration configuration)
    {
        File.WriteAllText("log.txt", String.Empty);
        configuration
            .MinimumLevel.Information()
            .WriteTo.Console(LogEventLevel.Information)
            .WriteTo.File("log.txt", shared: true);
    }
}