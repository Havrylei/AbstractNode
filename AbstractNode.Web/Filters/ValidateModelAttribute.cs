using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace ClinicApi.Resources.Filters
{
    /// <summary>
    ///     Validate Model Attribute
    /// </summary>
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        /// <summary>
        ///     On Action Executing
        /// </summary>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                return;
            }

            Dictionary<string, string> errors = context.ModelState
                .Where(x => x.Value.Errors.Any())
                .ToDictionary(key => key.Key, value => value.Value.Errors.First().ErrorMessage);

            context.Result = new BadRequestObjectResult(errors);
        }
    }
}
