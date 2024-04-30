using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAutomation.Domain.IService;
using VehicleAutomation.Domain.ViewModel;
using VehicleAutomation.Mediator.Query;

namespace VehicleAutomation.Mediator.Handler
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderVM>>
    {
        private readonly IOrderService _orderService;
        public GetAllOrderQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<List<OrderVM>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderService.GetOrderList();
            return orders;
        }
    }
}
