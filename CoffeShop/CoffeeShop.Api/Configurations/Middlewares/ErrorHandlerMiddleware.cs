using System.Reflection.Metadata;
using Azure;
using CoffeeShop.BusinessLogic.Exceptions;
using CoffeShop.Api.Common;
using Microsoft.AspNetCore.Mvc;

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
            catch (BusinessLogicException e)
            {
                _logger.LogError(e.Message);
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(String.Format(Translation.BadRequestObjectResultMessage, e.GetType(), e.Message));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(Translation.InternalServerErrorMessage);
            }
        }
    }
}
