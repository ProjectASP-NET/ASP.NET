using AutoMapper;
using DDLiquid.DataAccess.Interfaces;
using DDLiquid.BusinessLogic.Interfaces.Order;
using DDLiquid.Domain.Entities.Order;
using DDLiquid.Domain.Models.Order;

namespace DDLiquid.BusinessLogic.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDTO>> GetAllAsync()
        {
            var orders = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task<OrderDTO?> GetByIdAsync(int id)
        {
            var order = await _repo.GetByIdAsync(id);
            return order == null ? null : _mapper.Map<OrderDTO>(order);
        }

        public async Task<OrderDTO> CreateAsync(int userId, OrderCreateDTO dto)
        {
            var order = new OrderData
            {
                UserId = userId,
                OrderNumber = GenerateOrderNumber(),
                Status = Domain.Enums.OrderStatus.Pending,
                TotalAmount = dto.Items.Sum(i => i.Price * i.Quantity),
                DeliveryAddress = dto.DeliveryAddress,
                Comment = dto.Comment,
                Items = dto.Items.Select(i => new OrderItemData
                {
                    ProductId = i.ProductId,
                    ProductName = i.ProductName,
                    Price = i.Price,
                    Quantity = i.Quantity
                }).ToList()
            };

            var created = await _repo.CreateAsync(order);
            return _mapper.Map<OrderDTO>(created);
        }

        public async Task<OrderDTO?> UpdateStatusAsync(int id, OrderStatusUpdateDTO dto)
        {
            var order = await _repo.GetByIdAsync(id);
            if (order == null) return null;

            order.Status = dto.Status;
            var updated = await _repo.UpdateAsync(id, order);
            return updated == null ? null : _mapper.Map<OrderDTO>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        private static string GenerateOrderNumber()
        {
            return $"ORD-{DateTime.UtcNow:yyyyMMdd}-{Random.Shared.Next(1000, 9999)}";
        }
    }
}
