using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleAutomation.Domain.ViewModel;
using VehicleAutomation.Mediator.Query.InventoryQuery;

namespace VehicleAutomation.InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Inventorys = await _mediator.Send(new GetAllInventoryItemsQuery());
            return Ok(Inventorys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Inventory = await _mediator.Send(new GetInventoryItemByIdQuery(id));
            if (Inventory == null)
                return NotFound();
            return Ok(Inventory);
        }

        [HttpGet("bytype/{type}")]
        public async Task<IActionResult> GetByType(string type)
        {
            var InventoryItems = await _mediator.Send(new GetAllInventoryItemsByTypeQuery(type));
            return Ok(InventoryItems);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateInventory(InventoryVM Inventory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _mediator.Send(new CreateInventoryQuery(Inventory));
            if (result == null)
                return BadRequest("Error while Creating Inventory.");
            return Ok(result);
        }

        [HttpPost("createBulk")]
        public async Task<IActionResult> CreateBulkInventory(List<InventoryVM> inventoryItems)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _mediator.Send(new CreateBulkInventoryItemsQuery(inventoryItems));
            if (result == null)
                return BadRequest("Error while Creating Inventory Items.");
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventory(int id, InventoryVM Inventory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Inventory.Id = id;
            var result = await _mediator.Send(new UpdateInventoryQuery(Inventory));
            if (result == null)
                return BadRequest("Error while updating Inventory.");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(int id)
        {
            var result = await _mediator.Send(new DeleteInventoryQuery(id));
            if (!result)
                return BadRequest("Error while deleting Inventory.");
            return Ok("Inventory deleted Successfully.");
        }
    }
}
