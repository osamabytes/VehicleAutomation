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
    public class GetAllOrdersByCustomerQueryHandler : IRequestHandler<GetAllOrdersByCustomerQuery, List<OrderVM>>
    {
        private readonly IOrderService _orderService;
        public GetAllOrdersByCustomerQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<List<OrderVM>> Handle(GetAllOrdersByCustomerQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderService.GetOrdersListByCustomer(request.customerName);
            return orders;
        }
    }
}
