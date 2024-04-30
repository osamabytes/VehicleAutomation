using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAutomation.Mediator.Query.OrderQuery
{
    public class DeleteOrderQuery : IRequest<bool>
    {
        public int Id { get; set; }
        public DeleteOrderQuery(int id)
        {
            Id = id;
        }
    }
}
