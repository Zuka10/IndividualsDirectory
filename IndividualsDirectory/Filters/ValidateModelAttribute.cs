using IndividualsDirectory.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IndividualsDirectory.Api.Filters;

public class ValidateModelAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .Where(e => e.Value.Errors.Count > 0)
                .Select(e => new ValidationError
                {
                    Field = e.Key,
                    Messages = e.Value.Errors.Select(err => err.ErrorMessage).ToList()
                }).ToList();

            var errorResponse = new ErrorResponse
            {
                Type = "ValidationError",
                Errors = errors
            };

            context.Result = new BadRequestObjectResult(errorResponse);
        }
    }
}