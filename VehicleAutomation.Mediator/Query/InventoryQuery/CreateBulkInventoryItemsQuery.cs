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
    public class CreateBulkInventoryItemsQuery : IRequest<List<Inventory>>
    {
        public List<InventoryVM> InventoryItems { get; set; }
        public CreateBulkInventoryItemsQuery(List<InventoryVM> inventoryItems)
        {
            InventoryItems = inventoryItems;
        }
    }
}
