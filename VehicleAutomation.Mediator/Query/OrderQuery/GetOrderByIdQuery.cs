using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAutomation.Domain.ViewModel;

namespace VehicleAutomation.Mediator.Query.OrderQuery
{
    public class GetOrderByIdQuery : IRequest<OrderVM>
    {
        public int Id { get; set; }
        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
