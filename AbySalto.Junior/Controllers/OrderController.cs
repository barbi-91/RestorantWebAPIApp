using AbySalto.Junior.DTOs;
using AbySalto.Junior.Models;
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

        // Get all orders (2 - "Pregledavati postojeće narudžbe")
        [HttpGet]
        // api/order
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrdersAsync()
        {
            var orderDtos = await _orderService.GetAllOrdersAsync();
            return Ok(orderDtos);
        }

        // Change order status by id (3 - "Mijenjati status narudžbi")
        [HttpPatch("{orderId}/status")]
        // api/order/3/status
        public async Task<ActionResult<OrderDto?>> UpdateOrderStatusAsync(int orderId, [FromBody] OrderStatus status)
        {
            try
            {
                OrderDto? orderDto = await _orderService.UpdateOrderStatusAsync(orderId, status);
                if (orderDto == null)
                {
                    return BadRequest(new { errorMessage = "Order with orderId not found!" });
                }
                return Ok(orderDto);
            }
            catch (Exception)
            {
                return BadRequest(new { errorMessage = "An error occurred while updating order status." });
            }
        }

        // Get Total Amount by order id (4 - "Izračunavati ukupni iznos računa ")
        [HttpGet("{orderId}/total")]
        // api/order/3/total
        public async Task<ActionResult<decimal>> GetTotalAmountAsync(int orderId)
        {
            decimal total = await _orderService.GetTotalAmountAsync(orderId);
            if (total == 0m)
            {
                return BadRequest(new { errorMessage = "Order with orderId not found or sum is 0!" });
            }
            return Ok(total);
        }
    }
}