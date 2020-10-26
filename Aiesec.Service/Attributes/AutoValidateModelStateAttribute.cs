using Aiesec.Service.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Aiesec.Service.Attributes
{
    public class AutoValidateModelStateAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Controller controller = context.Controller as Controller;

            if (context.ModelState.IsValid)
            {
                await next().ConfigureAwait(false);
            }
            else
            {
                controller.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(context.ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary(x => x.Key, x => x.Value.Errors.Select(y => y.ErrorMessage)));
            }
        }
    }
}
