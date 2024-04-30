namespace VehicleAutomation.OrderAPI.Middleware
{
    public class CorelationIdMiddleware
    {
        private const string CorelationIdHeaderName = "X-Corelation-ID";
        private readonly RequestDelegate _next;

        public CorelationIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(CorelationIdHeaderName, out var correlationId))
            {
                correlationId = Guid.NewGuid().ToString();
                context.Request.Headers.Add(CorelationIdHeaderName, correlationId);
            }
            context.Response.OnStarting(() =>
            {
                if (!context.Response.Headers.ContainsKey(CorelationIdHeaderName))
                {
                    context.Response.Headers.Add(CorelationIdHeaderName, correlationId);
                }
                return Task.CompletedTask;
            });
            await _next(context);
        }
    }
}
