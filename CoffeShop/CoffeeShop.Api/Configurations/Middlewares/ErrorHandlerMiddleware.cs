using System.Reflection.Metadata;
using Azure;
using CoffeShop.Api.Common;

namespace CoffeShop.Api.Configurations.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;
        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await context.Response.WriteAsync(String.Format(Translation.ErrorMiddlewareHandlingMessage,ex.Message));
            }
        }
    }
}
