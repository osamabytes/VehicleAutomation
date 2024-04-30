using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAutomation.Domain.IService;
using VehicleAutomation.Domain.ViewModel;
using VehicleAutomation.Mediator.Query.InventoryQuery;

namespace VehicleAutomation.Mediator.Handler.InventoryQueryHandler
{
    public class GetInventoryItemByIdHandler : IRequestHandler<GetInventoryItemByIdQuery, InventoryVM>
    {
        private readonly IInventoryService _inventoryService;
        public GetInventoryItemByIdHandler(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        public async Task<InventoryVM> Handle(GetInventoryItemByIdQuery request, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryService.GetInventoryById(request.Id);
            return inventory;
        }
    }
}
