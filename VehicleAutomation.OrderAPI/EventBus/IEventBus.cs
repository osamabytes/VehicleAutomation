using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAutomation.OrderAPI.EventBus
{
    public interface IEventBus
    {
        Task PublishAsync<T>(T entity, CancellationToken cancellationToken = default) where T: class;
    }
}
