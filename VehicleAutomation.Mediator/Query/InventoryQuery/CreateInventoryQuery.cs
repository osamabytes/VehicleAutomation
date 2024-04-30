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
    public class CreateInventoryQuery : IRequest<Inventory>
    {
        public InventoryVM InventoryItems { get; set; }
        public CreateInventoryQuery(InventoryVM inventoryItems)
        {
            InventoryItems = inventoryItems;
        }
    }
}
