using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.ProxyExceptionHandlingLayer;

public interface IProxyExceptionHandler<TService>
{
    Task<IActionResult> ExecuteAsync<TResult>(Func<Task<TResult>> serviceFunc);
    Task<IActionResult> ExecuteAsync<TEntity, TResult>(Func<TEntity, Task<TResult>> serviceFunc, TEntity param);
    Task<IActionResult> ExecuteAsync<TEntity1,TEntity2, TResult>(Func<TEntity1,TEntity2, Task<TResult>> serviceFunc, TEntity1 param1,TEntity2 param2);
}