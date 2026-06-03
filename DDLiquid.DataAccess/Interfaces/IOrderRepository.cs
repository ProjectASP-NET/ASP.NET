using DDLiquid.Domain.Entities.Order;

namespace DDLiquid.DataAccess.Interfaces
{
    public interface IOrderRepository : IRepository<OrderData>
    {
        Task<IEnumerable<OrderData>> GetByUserIdAsync(int userId);
        Task<IEnumerable<OrderData>> GetByStatusAsync(int status);
        Task<IEnumerable<OrderData>> GetByDateRangeAsync(DateTime from, DateTime to);
        Task<int> GetOrderCountAsync();
        Task<decimal> GetTotalRevenueAsync();
        Task<IEnumerable<OrderData>> GetRecentOrdersAsync(int count);
    }
}
