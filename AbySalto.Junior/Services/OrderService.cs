using AbySalto.Junior.DTOs;
using AbySalto.Junior.Models;
using AbySalto.Junior.Repositories;
using AutoMapper;

namespace AbySalto.Junior.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Add new order (1 - "Dodavati nove narudžbe")
        public async Task<OrderDto> CreateOrderAsync(CreateOrderDto orderDto)
        {
            // Map DTO to entity
            var order = _mapper.Map<Order>(orderDto);

            // Set initial status
            order.Status = OrderStatus.Pending;

            // Set order time to now
            order.OrderTime = DateTime.UtcNow;

            // Save to database and return the created order
            var createdOrder = await _repository.CreateOrderAsync(order);

            // Map back to DTO
            var createdOrderDto = _mapper.Map<OrderDto>(createdOrder);

            return createdOrderDto;
        }

        // Get all orders (2 - "Pregledavati postojeće narudžbe")
        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _repository.GetAllOrdersAsync();
            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return ordersDto;
        }

        // Change order status by id (3 - "Mijenjati status narudžbi")
        public async Task<OrderDto?> UpdateOrderStatusAsync(int orderId, OrderStatus status)
        {
            var order = await _repository.UpdateOrderStatusAsync(orderId, status);
            var orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }

        // Get Total Amount by order id (4 - "Izračunavati ukupni iznos računa ")
        public async Task<decimal> GetTotalAmountAsync(int orderId)
        {
            // Get order by id
            Order? order = await _repository.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                return 0m;
            }
            return order.TotalAmount;
        }

        // Sort orders by Total Amount (5 - "Sortirati narudžbe po ukupnom iznosu")
        public Task<IEnumerable<OrderDto>> GetOrdersSortByTotalAmount()
        {
            throw new NotImplementedException();
        }
    }
}
