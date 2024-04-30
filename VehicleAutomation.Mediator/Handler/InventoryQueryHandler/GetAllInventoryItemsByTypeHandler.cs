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
    public class GetAllInventoryItemsByTypeHandler : IRequestHandler<GetAllInventoryItemsByTypeQuery, List<InventoryVM>>
    {
        private readonly IInventoryService _inventoryService;
        public GetAllInventoryItemsByTypeHandler(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        public async Task<List<InventoryVM>> Handle(GetAllInventoryItemsByTypeQuery request, CancellationToken cancellationToken)
        {
            var inventoryItems = await _inventoryService.GetInventoryByType(request.Type);
            return inventoryItems.ToList();
        }
    }
}
