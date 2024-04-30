using MassTransit;
using Serilog;
using Serilog.Events;
using VehicleAutomation.Data.DependencyInjection;
using VehicleAutomation.Infrastructure.DependencyInjection;
using VehicleAutomation.Mediator.DependencyInjection;
using VehicleAutomation.OrderAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDatabaseService(connectionStr);
builder.Services.AppServices();
//configure serilog logger
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {CorrelationId} {Message:lj}{NewLine}{Exception}")
    .WriteTo.File("logs/orderServiceLogs.txt", rollingInterval: RollingInterval.Day, outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {CorrelationId} {Message:lj}{NewLine}{Exception}")
    .Enrich.FromLogContext()
    .MinimumLevel
    .Override("Microsoft", LogEventLevel.Information)
);
// configure masstransit rabbitmq
var rabbitMQEnv = builder.Configuration.GetSection("RabbitMQ");
builder.Services.AddMassTransit(m =>
{
    m.UsingRabbitMq((context, config) =>
    {
        config.Host($"{rabbitMQEnv["Host"]}/{rabbitMQEnv["Port"]}", rabbitMQEnv["VirtualHost"], host =>
        {
            host.Username(rabbitMQEnv["username"]);
            host.Password(rabbitMQEnv["password"]);
        });
    });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// add mediator to service container
builder.Services.AddMediatorInjection();

var app = builder.Build();
// adding middlewares
app.UseMiddleware<ErrorHandlingMiddlware>();
app.UseMiddleware<CorelationIdMiddleware>();
app.Use(async (context, next) =>
{
    // fetch correlation id
    var correlationId = context.Request.Headers["X-Correlation-ID"].FirstOrDefault();
    // add the correlationId to the serilog context
    using (Serilog.Context.LogContext.PushProperty("correlationId", correlationId))
    {
        await next.Invoke();
    }
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
