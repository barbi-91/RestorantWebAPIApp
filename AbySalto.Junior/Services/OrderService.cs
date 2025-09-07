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

        public Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDto>> GetOrdersSortByTotalAmount()
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetTotalAmountAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto?> UpdateOrderStatusAsync(int orderId, OrderStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
