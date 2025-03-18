using IndividualsDirectory.Api.Models;
using IndividualsDirectory.Application.Exceptions;
using IndividualsDirectory.Infrastructure.Exceptions;
using Microsoft.Extensions.Localization;
using System.Net;
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
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        _logger.LogError(exception, "An exception occurred: {ExceptionType}", exception.GetType().Name);

        var errorDetails = GetErrorDetails(exception);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = errorDetails.StatusCode;

        var errorResponse = new ErrorResponse
        {
            Type = errorDetails.ErrorType,
            Errors = new List<ValidationError>
            {
                new ValidationError
                {
                    Field = string.Empty,
                    Messages = new List<string> { errorDetails.Message }
                }
            }
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }

    private (int StatusCode, string ErrorType, string Message) GetErrorDetails(Exception ex)
    {
        return ex switch
        {
            RelationshipAlreadyExistsException => ((int)HttpStatusCode.BadRequest, _localizer["ValidationError"], _localizer["Relationship already exists"]),
            RelationshipDoesNotExistsException => ((int)HttpStatusCode.BadRequest, _localizer["ValidationError"], _localizer["Relationship does not exist"]),
            RelatedPersonIsSameAsPersonException => ((int)HttpStatusCode.BadRequest, _localizer["ValidationError"], _localizer["Person and related person cannot be the same"]),
            PersonNotFoundException => ((int)HttpStatusCode.NotFound, _localizer["NotFoundError"], _localizer["Person not found with the provided ID"]),
            _ => ((int)HttpStatusCode.InternalServerError, _localizer["ServerError"], _localizer["An unexpected error occurred"])
        };
    }
}