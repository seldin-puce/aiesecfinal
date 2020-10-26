using Aiesec.Database.Context;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Aiesec.Service.Attributes
{
    public class TransactionAttribute : ActionFilterAttribute
    {
        private DbContext dbcontext;

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            dbcontext = context.HttpContext.RequestServices.GetService<DBContext>();
            IDbContextTransaction transaction = dbcontext.Database.CurrentTransaction ?? await dbcontext.Database.BeginTransactionAsync().ConfigureAwait(false);
            var result = await next().ConfigureAwait(false);
            if (result.Exception == null)
            {
                transaction.Commit();
                // TODO: Dodati log operaciju
            }
            else
            {
                transaction.Rollback();
                // TODO: Dodati log operaciju
            }
            transaction.Dispose();
        }
    }
}
