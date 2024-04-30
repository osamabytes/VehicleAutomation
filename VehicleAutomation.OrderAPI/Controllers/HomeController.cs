using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleAutomation.Domain.ViewModel;
using VehicleAutomation.Mediator.Query.OrderQuery;

namespace VehicleAutomation.OrderAPI.Controllers
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
            var orders = await _mediator.Send(new GetAllOrdersQuery());
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery(id));
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpGet("byname/{customername}")]
        public async Task<IActionResult> GetByCustomerName(string customername)
        {
            var orders = await _mediator.Send(new GetAllOrdersByCustomerQuery(customername));
            return Ok(orders);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder(OrderVM order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _mediator.Send(new AddOrderQuery(order));
            if (result == null)
                return BadRequest("Error while Creating Order.");
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderVM order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            order.OrderId = id;
            var result = await _mediator.Send(new UpdateOrderQuery(order));
            if (result == null)
                return BadRequest("Error while updating Order.");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _mediator.Send(new DeleteOrderQuery(id));
            if (!result)
                return BadRequest("Error while deleting Order.");
            return Ok("Order deleted Successfully.");
        }
    }
}
