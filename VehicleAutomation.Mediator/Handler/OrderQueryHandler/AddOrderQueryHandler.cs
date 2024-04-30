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
    public class AddOrderQueryHandler : IRequestHandler<AddOrderQuery, Order>
    {
        private readonly IOrderService _orderService;
        public AddOrderQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<Order> Handle(AddOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderService.CreateOrder(request.OrderVM);
            return order;
        }
    }
}
