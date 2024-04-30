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
    public class CreateInventoryHandler : IRequestHandler<CreateInventoryQuery, Inventory>
    {
        private readonly IInventoryService _inventoryService;
        public CreateInventoryHandler(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        public async Task<Inventory> Handle(CreateInventoryQuery request, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryService.CreateInventory(request.InventoryItems);
            return inventory;
        }
    }
}
