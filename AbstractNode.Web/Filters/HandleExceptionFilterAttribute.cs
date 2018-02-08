using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ClinicApi.Resources.Filters
{
    /// <summary>
    ///     Handle Exception Filter Attribute
    /// </summary>
    public class HandleExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        ///     On Exception
        /// </summary>
        public override void OnException(ExceptionContext context)
        {
            context.Result = new BadRequestObjectResult("Bad Request\n" + context.Exception.Message);
        }
    }
}
