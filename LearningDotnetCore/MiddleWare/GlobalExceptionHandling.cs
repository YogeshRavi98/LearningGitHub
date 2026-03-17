using System.Text.Json;

namespace LearningDotnetCore.MiddleWare
{
    public class GlobalExceptionHandling
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandling(RequestDelegate next) 
        {
          _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var result = new
                {
                    StatusCode = 500,
                    Message = "Internal Server Error"
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(result));
            }
        }

    }
}
