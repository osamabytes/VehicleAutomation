using MassTransit;
using VehicleAutomation.Domain.ViewModel;

namespace VehicleAutomation.InventoryAPI.Consumer
{
    public sealed class OrderCreatedEventConsumer : IConsumer<OrderVM>
    {
        private readonly ILogger<OrderCreatedEventConsumer> _logger;
        public OrderCreatedEventConsumer(ILogger<OrderCreatedEventConsumer> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<OrderVM> context)
        {
            _logger.LogInformation($"Order Received: {context.Message}");
            return Task.CompletedTask;
        }
    }
}
