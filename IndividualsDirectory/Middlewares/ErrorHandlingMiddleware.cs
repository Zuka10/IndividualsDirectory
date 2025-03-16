using IndividualsDirectory.Api.Models;
using IndividualsDirectory.Application.Exceptions;
using IndividualsDirectory.Infrastructure.Exceptions;
using Microsoft.Extensions.Localization;
using System.Text.Json;

namespace IndividualsDirectory.Api.Middlewares;

public class ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger, IStringLocalizer<ErrorHandlingMiddleware> localizer)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger = logger;
    private readonly IStringLocalizer<ErrorHandlingMiddleware> _localizer = localizer;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (RelationshipAlreadyExistsException)
        {
            await CreateErrorResponse(context,
                StatusCodes.Status400BadRequest,
                _localizer["ValidationError"],
                _localizer["Relationship already exists"]);
        }
        catch (RelationshipDoesNotExistsException)
        {
            await CreateErrorResponse(context,
                StatusCodes.Status400BadRequest,
                _localizer["ValidationError"],
                _localizer["Relationship does not exists"]);
        }
        catch (RelatedPersonIsSameAsPersonException)
        {
            await CreateErrorResponse(context,
                StatusCodes.Status400BadRequest,
                _localizer["ValidationError"],
                _localizer["Person and related person cannot be the same"]);
        }
        catch (PersonNotFoundException)
        {
            await CreateErrorResponse(context,
                StatusCodes.Status404NotFound,
                _localizer["NotFoundError"],
                _localizer["Person not found with following id"]);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred");
            await CreateErrorResponse(context,
                StatusCodes.Status500InternalServerError,
                _localizer["ServerError"],
                _localizer["An unexpected error occurred"]);
        }
    }

    private static Task CreateErrorResponse(
        HttpContext context,
        int statusCode,
        string errorType,
        string errorMessage)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var errorResponse = new ErrorResponse
        {
            Type = errorType,
            Errors = new List<ValidationError>
            {
                new ValidationError
                {
                    Field = string.Empty,
                    Messages = new List<string> { errorMessage }
                }
            }
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }
}