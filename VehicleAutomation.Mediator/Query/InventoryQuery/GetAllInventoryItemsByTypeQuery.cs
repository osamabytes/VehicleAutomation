using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAutomation.Domain.ViewModel;

namespace VehicleAutomation.Mediator.Query.InventoryQuery
{
    public class GetAllInventoryItemsByTypeQuery : IRequest<List<InventoryVM>>
    {
        public string Type { get; set; }
        public GetAllInventoryItemsByTypeQuery(string type)
        {
            Type = type;
        }
    }
}
