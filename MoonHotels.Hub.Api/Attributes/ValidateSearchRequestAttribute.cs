using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoonHotels.Hub.Api.Models.Request;

namespace MoonHotels.Hub.Api.Attributes
{
    public class ValidateSearchRequestAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                // Si el modelo no es válido, devolver un resultado BadRequest con los errores de validación
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }

            if (context.ActionArguments.Count != 1)
            {
                context.ModelState.AddModelError(nameof(context.ActionArguments.Count), $"The search request must only have one argument.");
            }

            if (!context.ActionArguments.First().GetType().Equals(typeof(EngineHubSearchRequest)))
            {
                context.ModelState.AddModelError("Request from the body.", $"The request type must be {nameof(EngineHubSearchRequest)}.");
            }

            if (!(context.ActionArguments.First().Value as EngineHubSearchRequest)!.IsValid())
            {
                context.ModelState.AddModelError("Request from the body.", $"Is not valid.");
            }
        }
    }
}
