using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AbstractNode.Web.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
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
