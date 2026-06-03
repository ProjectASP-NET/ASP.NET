using DDLiquid.Domain.Models.Order;

namespace DDLiquid.BusinessLogic.Interfaces.Order
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetAllAsync();
        Task<OrderDTO?> GetByIdAsync(int id);
        Task<OrderDTO> CreateAsync(int userId, OrderCreateDTO dto);
        Task<OrderDTO?> UpdateStatusAsync(int id, OrderStatusUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
