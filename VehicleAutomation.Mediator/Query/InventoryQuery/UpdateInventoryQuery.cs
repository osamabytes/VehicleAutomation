using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAutomation.Domain.Model;
using VehicleAutomation.Domain.ViewModel;

namespace VehicleAutomation.Mediator.Query.InventoryQuery
{
    public class UpdateInventoryQuery : IRequest<Inventory>
    {
        public InventoryVM Inventory { get; set; }
        public UpdateInventoryQuery(InventoryVM inventory)
        {
            Inventory = inventory;
        }
    }
}
