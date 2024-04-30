using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAutomation.Domain.IService;
using VehicleAutomation.Mediator.Query.OrderQuery;

namespace VehicleAutomation.Mediator.Handler.OrderQueryHandler
{
    public class DeleteOrderQueryHandler : IRequestHandler<DeleteOrderQuery, bool>
    {
        private readonly IOrderService _orderService;
        public DeleteOrderQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<bool> Handle(DeleteOrderQuery request, CancellationToken cancellationToken)
        {
            var result = await _orderService.DeleteOrder(request.Id);
            return result;
        }
    }
}
