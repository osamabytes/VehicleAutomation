using MassTransit;
using MediatR;
using VehicleAutomation.Domain.ViewModel;
using VehicleAutomation.Mediator.Query.InventoryQuery;

namespace VehicleAutomation.InventoryAPI.Consumer
{
    public sealed class OrderCreatedEventConsumer : IConsumer<OrderVM>
    {
        private readonly ILogger<OrderCreatedEventConsumer> _logger;
        private readonly IMediator _mediator;
        public OrderCreatedEventConsumer(ILogger<OrderCreatedEventConsumer> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        public Task Consume(ConsumeContext<OrderVM> context)
        {
            _logger.LogInformation($"Order Received: {context.Message}");
            var result = _mediator.Send(new TestItemQuery()).Result;
            return Task.CompletedTask;
        }
    }
}
