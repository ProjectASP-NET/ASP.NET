using DDLiquid.DataAccess.Interfaces;
using DDLiquid.DataAccess.DB;
using DDLiquid.Domain.Entities.Order;
using Microsoft.EntityFrameworkCore;

namespace DDLiquid.DataAccess.Reps
{
    public class OrderRepository : OrderContextRepository<OrderData>, IOrderRepository
    {
        private readonly new OrderDbContext _context;

        public OrderRepository(OrderDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<OrderData>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Items)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }

        public override async Task<OrderData?> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<OrderData>> GetByUserIdAsync(int userId)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderData>> GetByStatusAsync(int status)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .Where(o => (int)o.Status == status)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderData>> GetByDateRangeAsync(DateTime from, DateTime to)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .Where(o => o.CreatedAt >= from && o.CreatedAt <= to)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }

        public async Task<int> GetOrderCountAsync()
        {
            return await _context.Orders.CountAsync();
        }

        public async Task<decimal> GetTotalRevenueAsync()
        {
            return await _context.Orders
                .Where(o => o.Status == Domain.Enums.OrderStatus.Delivered)
                .SumAsync(o => o.TotalAmount);
        }

        public async Task<IEnumerable<OrderData>> GetRecentOrdersAsync(int count)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .OrderByDescending(o => o.CreatedAt)
                .Take(count)
                .ToListAsync();
        }
    }
}
