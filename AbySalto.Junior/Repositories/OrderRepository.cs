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
            List<Order> orders = await _context.Orders
                .Include(o => o.Items)
                .ToListAsync();
            return orders;
        }

        // Change order status by id (3 - "Mijenjati status narudžbi")
        public async Task<Order?> UpdateOrderStatusAsync(int orderId, OrderStatus status)
        {
            Order? orderById = await GetOrderByIdAsync(orderId);
            if (orderById == null)
            {
                return null;
            }
            orderById.Status = status;
            await _context.SaveChangesAsync();

            return orderById;
        }

        // Sort orders by Total Amount (5 - "Sortirati narudžbe po ukupnom iznosu")
        public Task<IEnumerable<Order>> GetOrdersSortByTotalAmount()
        {
            throw new NotImplementedException();
        }

        // Helper method get single method by id
        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            Order? orderById = await _context.Orders
                .Include(o => o.Items)
                .SingleOrDefaultAsync(o => o.Id == orderId);
            return orderById;
        }
    }
}
