using IndividualsDirectory.Api.Models;

namespace IndividualsDirectory.Api.Middlewares;

public class ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred");

            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        return context.Response.WriteAsync(new ErrorResponse
        {
            Type = "ServerError",
            Errors = new List<ValidationError>
            {
                new ValidationError
                {
                    Field = string.Empty,
                    Messages = new List<string> { "An unexpected error occurred" }
                }
            }
        }.ToString());
    }
}