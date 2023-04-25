using Contracts;
using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace CompanyEmployees.Extensions;

/// <summary>
/// ExceptionMiddlewareExtensions is a static class containing an extension method to configure
/// a custom exception handler middleware in the CompanyEmployees project.
/// </summary>
public static class ExceptionMiddlewareExtensions
{
    /// <summary>
    /// Configures a custom exception handler middleware that logs the error and writes a JSON response.
    /// </summary>
    /// <param name="app">The IApplicationBuilder instance on which the middleware is added.</param>
    /// <param name="logger">The ILoggerManager instance used for logging errors.</param>
    public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        BadRequestException => StatusCodes.Status400BadRequest,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    logger.LogError($"Something went wrong: {contextFeature.Error}");

                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message
                    }.ToString());
                }
            });
        });
    }
}
