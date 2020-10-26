using Aiesec.Service.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Aiesec.Service.Attributes
{
   public class HandleModelStateExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ModelStateException)
            {
                ModelStateException exception = (ModelStateException)context.Exception;
                context.ModelState.AddModelError(exception.Key, exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
    }
}
