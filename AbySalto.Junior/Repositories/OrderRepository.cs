using AbySalto.Junior.Infrastructure.Database;
using AbySalto.Junior.Models;
using Microsoft.EntityFrameworkCore;

namespace AbySalto.Junior.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        // Add new order (1 - "Dodavati nove narudžbe")
        public async Task<Order> CreateOrderAsync(Order order)
        {
            // Add the order to the database
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // After SaveChanges, order.Id and other DB-generated fields are populated
            return order;
        }

        // Get all orders (2 - "Pregledavati postojeće narudžbe")
        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders
                .Include(o => o.Items)
                .ToListAsync();
            return orders;
        }

        // Change order status by id (3 - "Mijenjati status narudžbi")
        public Task<Order?> UpdateOrderStatusAsync(int orderId, OrderStatus status)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Order>> GetOrdersSortByTotalAmount()
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetTotalAmountAsync(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
