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
    public async Task<IActionResult> ExecuteAsync<TEntity,TResult>(Func<TEntity, Task<TResult>> serviceFunc,
        TEntity param)
    {
        try
        {
            return new OkObjectResult(await serviceFunc.Invoke(param));
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new BadRequestObjectResult(String.Format(Translation.BadRequestObjectResultMessage,e.GetType(),e.Message));
        }
    }
    public async Task<IActionResult> ExecuteAsync<TEntity1, TEntity2, TResult>(Func<TEntity1, TEntity2, Task<TResult>> serviceFunc, TEntity1 param1, TEntity2 param2)
    {
        try
        {
            return new OkObjectResult(await serviceFunc.Invoke(param1,param2));
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new BadRequestObjectResult(String.Format(Translation.BadRequestObjectResultMessage,e.GetType(),e.Message));
        }
    }
    public async Task<IActionResult> ExecuteAsync<TResult>(Func<Task<TResult>> serviceFunc)
    {
        try
        {
            return new OkObjectResult(await serviceFunc.Invoke());
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new BadRequestObjectResult(String.Format(Translation.BadRequestObjectResultMessage,e.GetType(),e.Message));
        }
    }
}