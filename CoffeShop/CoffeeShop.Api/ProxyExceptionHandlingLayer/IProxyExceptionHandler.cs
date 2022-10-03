using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.ProxyExceptionHandlingLayer;

public interface IProxyExceptionHandler<TService>
{
    Task<IActionResult> ExecuteAsync<TResult>(Func<Task<TResult>> serviceFunc);
    Task<IActionResult> ExecuteAsync<TEntity, TResult>(Func<TEntity, Task<TResult>> serviceFunc, TEntity param);
}