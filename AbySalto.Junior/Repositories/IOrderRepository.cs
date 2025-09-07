using AbySalto.Junior.Models;

namespace AbySalto.Junior.Repositories
{
    public interface IOrderRepository
    {
        // Add new order (1 - "Dodavati nove narudžbe")
        Task<Order> CreateOrderAsync(Order order);

        // Get all orders (2 - "Pregledavati postojeće narudžbe")
        Task<IEnumerable<Order>> GetAllOrdersAsync();

        // Change order status by id (3 - "Mijenjati status narudžbi")
        Task<Order?> UpdateOrderStatusAsync(int orderId, OrderStatus status);

        // Helper method get single method by id
        Task<Order?> GetOrderByIdAsync(int orderId);
    }
}
