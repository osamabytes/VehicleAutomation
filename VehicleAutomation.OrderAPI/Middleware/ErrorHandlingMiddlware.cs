using System.Net;
using System.Text.Json;

namespace VehicleAutomation.OrderAPI.Middleware
{
    public class ErrorHandlingMiddlware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _environment;
        public ErrorHandlingMiddlware(RequestDelegate next, IHostEnvironment environment)
        {
            _next = next;
            _environment = environment;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = _environment.IsDevelopment()
                    ? new APIException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                    : new APIException(context.Response.StatusCode, ex.Message, "Internal Server Error");
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var json = JsonSerializer.Serialize(response, options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
