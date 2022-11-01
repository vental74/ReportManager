namespace ReportManager.Api.Middleware
{
    public class MiddlewareRequestLogger
    {
        private RequestDelegate _next;
        private readonly Domain.Interfaces.ILogger _logger;
        public MiddlewareRequestLogger(RequestDelegate next,Domain.Interfaces.ILogger logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            finally
            {
                await _logger.Information(
                    $"Request {httpContext.Request?.Method} " +
                    $"{httpContext.Request?.Path.Value} => " +
                    $"{httpContext.Response?.StatusCode}"
                    );
            }
        }
    }
}
