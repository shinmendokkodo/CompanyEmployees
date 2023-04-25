using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace CompanyEmployees.Presentation.ActionFilters;

/// <summary>
/// The ValidationFilterAttribute class is a custom Action Filter that validates the input data received by an action method.
/// </summary>
public class ValidationFilterAttribute : IActionFilter
{
    /// <summary>
    /// Initializes a new instance of the ValidationFilterAttribute class.
    /// </summary>
    public ValidationFilterAttribute()
    {
    }

    /// <summary>
    /// Executes before the action method is invoked. Validates the input data and sets the action result accordingly.
    /// </summary>
    /// <param name="context">The ActionExecutingContext object containing information about the current request.</param>
    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Retrieve the action and controller names from the route data.
        var action = context.RouteData.Values["action"];
        var controller = context.RouteData.Values["controller"];

        // Find the parameter object in the action arguments that has a "Dto" suffix.
        var param = context.ActionArguments
            .SingleOrDefault(x => x.Value.ToString().Contains("Dto")).Value;

        // If the parameter object is null, set the action result to a BadRequestObjectResult.
        if (param is null)
        {
            context.Result = new BadRequestObjectResult($"Object is null. Controller: {controller}, action: {action}");
            return;
        }

        // If the model state is not valid, set the action result to an UnprocessableEntityObjectResult.
        if (!context.ModelState.IsValid)
            context.Result = new UnprocessableEntityObjectResult(context.ModelState);
    }

    /// <summary>
    /// Executes after the action method is invoked. This method is intentionally left empty.
    /// </summary>
    /// <param name="context">The ActionExecutedContext object containing information about the current request.</param>
    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Method intentionally left empty.
    }
}
