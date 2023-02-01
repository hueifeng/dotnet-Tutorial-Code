namespace _002
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomMiddleware> _logger;

        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogWarning($"Before Invoke {context.Request.Path}");
            await _next(context);
            _logger.LogWarning($"After Invoke {context.Request.Path}");
        }
    }

}