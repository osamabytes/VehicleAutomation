using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAutomation.Domain.IService;
using VehicleAutomation.Mediator.Query.InventoryQuery;

namespace VehicleAutomation.Mediator.Handler.InventoryQueryHandler
{
    public class DeleteInventoryHandler : IRequestHandler<DeleteInventoryQuery, bool>
    {
        private readonly IInventoryService _inventoryService;
        public DeleteInventoryHandler(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public async Task<bool> Handle(DeleteInventoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _inventoryService.DeleteInventory(request.Id);
            return result;
        }
    }
}
