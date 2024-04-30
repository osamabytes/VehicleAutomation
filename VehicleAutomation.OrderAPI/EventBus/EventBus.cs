using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAutomation.OrderAPI.EventBus;

namespace VehicleAutomation.Infrastructure.MessageBroker
{
    public sealed class EventBus : IEventBus
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public EventBus(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        public async Task PublishAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class
        {
            await _publishEndpoint.Publish(entity, cancellationToken);
        }
    }
}
