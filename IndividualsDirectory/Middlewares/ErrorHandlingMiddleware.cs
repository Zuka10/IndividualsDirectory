using IndividualsDirectory.Api.Models;
using IndividualsDirectory.Application.Exceptions;
using IndividualsDirectory.Infrastructure.Exceptions;
using System.Text.Json;

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
        catch (RelationshipAlreadyExistsException)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            await context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorResponse
            {
                Type = "ValidationError",
                Errors = new List<ValidationError>
            {
                new ValidationError
                {
                    Field = string.Empty,
                    Messages = new List<string> { "The relationship already exists." }
                }
            }
            }));
        }
        catch (RelationshipDoesNotExistsException)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            await context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorResponse
            {
                Type = "ValidationError",
                Errors = new List<ValidationError>
            {
                new ValidationError
                {
                    Field = string.Empty,
                    Messages = new List<string> { "The relationship does not exist." }
                }
            }
            }));
        }
        catch (PersonNotFoundException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status404NotFound;

            // Create JSON error response
            await context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorResponse
            {
                Type = "NotFoundError",
                Errors = new List<ValidationError>
            {
                new ValidationError
                {
                    Field = string.Empty,
                    Messages = new List<string> { "Person not found with following id." }
                }
            }
            }));
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

        return context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorResponse
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
        }.ToString()));
    }
}