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
    public class UpdateInventoryHandler : IRequestHandler<UpdateInventoryQuery, Inventory>
    {
        private readonly IInventoryService _inventoryService;
        public UpdateInventoryHandler(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public async Task<Inventory> Handle(UpdateInventoryQuery request, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryService.UpdateInventory(request.Inventory);
            return inventory;
        }
    }
}
