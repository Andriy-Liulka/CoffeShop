using CoffeeShop.BusinessLogic.Exceptions;
using System.Net;
using System.Web.Http.Filters;

namespace CoffeShop.Api.Filters.ExceptionFilters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public bool AllowMultiple => true;

        public new Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext,
            CancellationToken cancellationToken)
        {
            if (actionExecutedContext.Exception != null &&
                    actionExecutedContext.Exception is BusinessLogicException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(
                HttpStatusCode.BadRequest, "BusinessLogicException");
            }
            else if (actionExecutedContext.Exception != null &&
                actionExecutedContext.Exception is Exception)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(
                HttpStatusCode.BadRequest, "Internal server error");
            }
            return Task.FromResult<object>(null);
        }
    }
}
