using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAutomation.Domain.IService;
using VehicleAutomation.Domain.Model;
using VehicleAutomation.Mediator.Query.OrderQuery;

namespace VehicleAutomation.Mediator.Handler.OrderQueryHandler
{
    public class UpdateOrderQueryHandler : IRequestHandler<UpdateOrderQuery, Order>
    {
        private readonly IOrderService _orderService;
        public UpdateOrderQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<Order> Handle(UpdateOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderService.UpdateOrder(request.OrderVM);
            return order;
        }
    }
}
