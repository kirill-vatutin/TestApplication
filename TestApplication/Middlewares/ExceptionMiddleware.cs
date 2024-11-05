using TestApplication.API.Response;

namespace TestApplication.API.Middlewares;

public class ExceptionMiddleware(
    ILogger<ExceptionMiddleware> logger,
    RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);

            var responseError = new ResponseError("server.internal", ex.Message, null);
            var envelope = Envelope.Error([responseError]);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsJsonAsync(envelope);
        }
    }
}

public static class ExceptionMiddlewaresExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(
        this IApplicationBuilder builder) =>
        builder.UseMiddleware<ExceptionMiddleware>();
}
