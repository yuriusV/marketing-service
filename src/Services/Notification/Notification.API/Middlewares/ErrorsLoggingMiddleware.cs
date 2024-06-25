namespace Notification.API.Middlewares;
public class ErrorsLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorsLoggingMiddleware> _logger;

    public ErrorsLoggingMiddleware(RequestDelegate next, ILogger<ErrorsLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var originalBodyStream = context.Response.Body;

        try
        {
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);

                if (context.Response.StatusCode >= 400)
                {
                    context.Response.Body.Seek(0, SeekOrigin.Begin);
                    string responseBodyContent = await new StreamReader(context.Response.Body).ReadToEndAsync();

                    _logger.LogWarning("HTTP pipeline: {RequestMethod} {RequestPath} responded with status code {StatusCode}. Response body: {ResponseBody}",
                        context.Request.Method, context.Request.Path, context.Response.StatusCode, responseBodyContent);
                }

                context.Response.Body.Seek(0, SeekOrigin.Begin);

                await responseBody.CopyToAsync(originalBodyStream);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while processing HTTP request.");
            throw;
        }
        finally
        {
            context.Response.Body = originalBodyStream;
        }
    }
}