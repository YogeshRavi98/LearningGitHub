namespace LearningDotnetCore.MiddleWare
{
    public class Logging
    {
        private readonly RequestDelegate _next;
        public ILogger<Logging> _logger;

        public Logging (RequestDelegate next, ILogger<Logging> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                throw;
            }
        }
    }
}
