using CoffeShop.Api.Common;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.ProxyExceptionHandlingLayer;

public class ProxyExceptionHandler<TService> : IProxyExceptionHandler<TService>
{
    private readonly ILogger<TService> _logger;

    public ProxyExceptionHandler(ILogger<TService> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> ExecuteAsync<TEntity>(Func<TEntity, Task<IActionResult>> serviceFunc,
        TEntity param)
    {
        try
        {
            return await serviceFunc.Invoke(param);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new BadRequestObjectResult(String.Format(Translation.BadRequestObjectResultMessage,e.GetType(),e.Message));
        }
    }

    public async Task<IActionResult> ExecuteAsync(Func<Task<IActionResult>> serviceFunc)
    {
        try
        {
            return await serviceFunc.Invoke();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new BadRequestObjectResult(String.Format(Translation.BadRequestObjectResultMessage,e.GetType(),e.Message));
        }
    }
}