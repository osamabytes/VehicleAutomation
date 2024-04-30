using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAutomation.Domain.IService;
using VehicleAutomation.Domain.ViewModel;
using VehicleAutomation.Mediator.Query.OrderQuery;

namespace VehicleAutomation.Mediator.Handler.OrderQueryHandler
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderVM>
    {
        private readonly IOrderService _orderService;
        public GetOrderByIdQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<OrderVM> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetOrderById(request.Id);
            return order;
        }
    }
}
