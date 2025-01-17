using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Exceptions.Handler
{
    #region aboutMethodAndPackages
    //Use fluent validation packages that include ASP.Net libraries.
    // install Fluent Validation packages in here to access ASP.Net libraries.
    //Fluent Validation packages will allow us to access ASP.Net core specific APIs in our class library.
    //In this method, our custom handler class will lock the exceptions and determine the response based
    // on the exception type and the format response as a problem details object.
    #endregion

    public class CustomExceptionHandler(ILogger<CustomExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
        {
            logger.LogError("Error Message:{exceptionMessage},time of occurence{time}", exception.Message, DateTime.UtcNow);

            (string Details, string Title, int statusCode) details = exception switch
            {
                InternalServerException =>
                 (
                   exception.Message,
                   exception.GetType().Name,
                   context.Response.StatusCode = StatusCodes.Status500InternalServerError
                ),
                ValidationException =>
                (
                        exception.Message,
                        exception.GetType().Name,
                        context.Response.StatusCode = StatusCodes.Status400BadRequest
                ),
                BadRequestException => (
                    exception.Message,
                    exception.GetType().Name,
                    context.Response.StatusCode = StatusCodes.Status400BadRequest
                    ),
                NotFoundException =>
                    (
                        exception.Message,
                        exception.GetType().Name,
                        context.Response.StatusCode = StatusCodes.Status404NotFound
                    ),
                _ =>
                    (
                        exception.Message,
                        exception.GetType().Name,
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError
                     )
            };


            var problemDetails = new ProblemDetails
            {
                Title = details.Title,
                Status = details.statusCode,
                Detail = details.Details,
                Instance = context.Request.Path
            };

            problemDetails.Extensions.Add("traceId",context.TraceIdentifier);

            if (exception is ValidationException validationException)
            {
                problemDetails.Extensions.Add("ValidationErrors",validationException.Errors);
            }

            await context.Response.WriteAsJsonAsync(problemDetails,cancellationToken:cancellationToken);
            return true;
        }
    }
}
