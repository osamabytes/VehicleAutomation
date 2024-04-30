using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAutomation.Domain.IService;
using VehicleAutomation.Domain.Model;
using VehicleAutomation.Mediator.Query.InventoryQuery;

namespace VehicleAutomation.Mediator.Handler.InventoryQueryHandler
{
    public class CreateBulkInventoryItemsHandler : IRequestHandler<CreateBulkInventoryItemsQuery, List<Inventory>>
    {
        private readonly IInventoryService _inventoryService;
        public CreateBulkInventoryItemsHandler(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public async Task<List<Inventory>> Handle(CreateBulkInventoryItemsQuery request, CancellationToken cancellationToken)
        {
            var inventoryItems = await _inventoryService.CreateBulkInventory(request.InventoryItems);
            return inventoryItems.ToList();
        }
    }
}
