using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAutomation.Domain.ViewModel;

namespace VehicleAutomation.Mediator.Query
{
    public class GetAllOrdersQuery : IRequest<List<OrderVM>>
    {
    }
}
