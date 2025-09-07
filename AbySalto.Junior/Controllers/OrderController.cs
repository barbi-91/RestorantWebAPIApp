using AbySalto.Junior.DTOs;
using AbySalto.Junior.Services;
using Microsoft.AspNetCore.Mvc;

namespace AbySalto.Junior.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // Add new order (1 - "Dodavati nove narudžbe")
        [HttpPost]
        // api/order
        public async Task<ActionResult<OrderDto>> CreateOrderAsync([FromBody] CreateOrderDto createOrderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.IsValid);
            }
            try
            {
                // Create the orderDto using the service and return the result
                var orderDto = await _orderService.CreateOrderAsync(createOrderDto);
                return Ok(orderDto);
            }
            catch (Exception)
            {
                // TODO: log this exception
                //var error = ex.Message;

                return BadRequest(new { errorMessage = "Error has occured!" });
            }
        }
    }
}
