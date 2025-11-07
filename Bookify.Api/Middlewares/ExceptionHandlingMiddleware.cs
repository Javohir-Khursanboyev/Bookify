using Bookify.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

public class ExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Exception occured: {Message}", exception.Message);

            var problemDetails = GetProblemDetails(exception);

            context.Response.StatusCode = (int)problemDetails.Status!;

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }

    private static ProblemDetails GetProblemDetails(Exception exception)
    {
        return exception switch
        {
            ValidationException validationException => new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "ValidationFailure",
                Title = "Validation error",
                Detail = "One or more validation error occured",
                Extensions = new Dictionary<string, object?>
                {
                    { "errors", validationException.Errors },
                }
            },
            _ => new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "ServerError",
                Title = "Server Error",
                Detail = "An expected error occured"
            }
        };
    }

    private static ExceptionDetails GetExceptionDetails(Exception exception)
    {
        return exception switch
        {
            ValidationException validationException => new ExceptionDetails(
                StatusCodes.Status400BadRequest,
                "ValidationFailure",
                "Validation error",
                "One or more validation error occured",
                validationException.Errors),
            _ => new ExceptionDetails(
                StatusCodes.Status500InternalServerError,
                "ServerError",
                "Server error",
                "An expected error occured",
                null)
        };
    }

    internal sealed record ExceptionDetails(
    int Status,
    string Type,
    string Title,
    string Detail,
    IEnumerable<object>? Errors);
}