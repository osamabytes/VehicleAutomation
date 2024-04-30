using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAutomation.Domain.ViewModel;

namespace VehicleAutomation.Mediator.Query.InventoryQuery
{
    public class GetInventoryItemByIdQuery : IRequest<InventoryVM>
    {
        public int Id { get; set; }
        public GetInventoryItemByIdQuery(int id)
        {
            Id = id;
        }
    }
}
