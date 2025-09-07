using AbySalto.Junior.DTOs;
using AbySalto.Junior.Models;

namespace AbySalto.Junior.Services
{
    public interface IOrderService
    {
        // Add new order (1 - "Dodavati nove narudžbe")
        Task<OrderDto> CreateOrderAsync(CreateOrderDto orderDto);

        // Get all orders (2 - "Pregledavati postojeće narudžbe")
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();

        // Change order status by id (3 - "Mijenjati status narudžbi")
        Task<OrderDto?> UpdateOrderStatusAsync(int orderId, OrderStatus status);

        // Get Total Amount by order id (4 - "Izračunavati ukupni iznos računa ")
        Task<decimal> GetTotalAmountAsync(int orderId);

        // Sort orders by Total Amount (5 - "Sortirati narudžbe po ukupnom iznosu")
        Task<IEnumerable<OrderDto>> GetOrdersSortByTotalAmount();
    }
}
