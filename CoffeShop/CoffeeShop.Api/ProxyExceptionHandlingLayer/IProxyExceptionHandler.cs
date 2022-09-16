using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.ProxyExceptionHandlingLayer;

public interface IProxyExceptionHandler<TService>
{
    public Task<IActionResult> ExecuteAsync(Func<Task<IActionResult>> serviceFunc);
    Task<IActionResult> ExecuteAsync<TEntity>(Func<TEntity, Task<IActionResult>> serviceFunc, TEntity param);
}