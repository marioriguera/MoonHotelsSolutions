using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoonHotels.Hub.Api.Models.Request;

namespace MoonHotels.Hub.Api.Attributes
{
    /// <summary>
    /// Action filter attribute for validating search requests.
    /// </summary>
    public class ValidateSearchRequestAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Overrides the method called before the action method is invoked.
        /// </summary>
        /// <param name="context">The context for the action execution.</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.Count != 1)
            {
                context.ModelState.AddModelError(nameof(context.ActionArguments.Count), $"The search request must only have one argument.");
            }

            if (!(context.ActionArguments.First().Value?.GetType().Equals(typeof(EngineHubSearchRequest)) ?? false))
            {
                context.ModelState.AddModelError("Request type.", $"The request type must be {nameof(EngineHubSearchRequest)}.");
            }

            if (!(context.ActionArguments.First().Value as EngineHubSearchRequest)!.IsValid())
            {
                context.ModelState.AddModelError("Request model.", $"Is not valid. The invalidations are as follows: {string.Join(", ", (context.ActionArguments.First().Value as EngineHubSearchRequest)!.Invalidations())}");
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }
        }
    }
}
