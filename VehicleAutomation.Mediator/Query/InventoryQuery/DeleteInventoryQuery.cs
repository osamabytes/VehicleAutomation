using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAutomation.Mediator.Query.InventoryQuery
{
    public class DeleteInventoryQuery : IRequest<bool>
    {
        public int Id { get; set; }
        public DeleteInventoryQuery(int id)
        {
            Id = id;
        }
    }
}
