using DDLiquid.DataAccess.DB;
using DDLiquid.DataAccess.Interfaces;
using DDLiquid.BusinessLogic.Interfaces.Admin;
using DDLiquid.Domain.Entities.Order;
using DDLiquid.Domain.Enums;
using DDLiquid.Domain.Models.Admin;
using Microsoft.EntityFrameworkCore;

namespace DDLiquid.BusinessLogic.Services.Admin
{
    public class AdminService : IAdminService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly OrderDbContext _orderDb;
        private readonly UserDbContext _userDb;
        private readonly ProductDbContext _productDb;

        public AdminService(
            IOrderRepository orderRepo,
            OrderDbContext orderDb,
            UserDbContext userDb,
            ProductDbContext productDb)
        {
            _orderRepo = orderRepo;
            _orderDb = orderDb;
            _userDb = userDb;
            _productDb = productDb;
        }

        public async Task<AdminStatsDTO> GetStatsAsync()
        {
            var totalUsers = await _userDb.Users.CountAsync();
            var totalProducts = await _productDb.Products.CountAsync();
            var totalOrders = await _orderDb.Orders.CountAsync();
            var revenue = await _orderDb.Orders
                .Where(o => o.Status == OrderStatus.Delivered)
                .SumAsync(o => o.TotalAmount);

            var ordersByStatus = await _orderDb.Orders
                .GroupBy(o => o.Status)
                .Select(g => new OrderStatusCountDTO
                {
                    Status = g.Key.ToString(),
                    Count = g.Count()
                }).ToListAsync();

            var recentOrders = await _orderRepo.GetRecentOrdersAsync(5);

            var popularProducts = await _orderDb.OrderItems
                .Where(i => i.Order.Status == OrderStatus.Delivered)
                .GroupBy(i => new { i.ProductId, i.ProductName })
                .Select(g => new PopularProductDTO
                {
                    ProductId = g.Key.ProductId,
                    ProductName = g.Key.ProductName,
                    TotalSold = g.Sum(i => i.Quantity),
                    Revenue = g.Sum(i => i.Price * i.Quantity)
                })
                .OrderByDescending(p => p.TotalSold)
                .Take(5)
                .ToListAsync();

            return new AdminStatsDTO
            {
                TotalUsers = totalUsers,
                TotalProducts = totalProducts,
                TotalOrders = totalOrders,
                Revenue = revenue,
                OrdersByStatus = ordersByStatus,
                RecentOrders = recentOrders.Select(o => new DDLiquid.Domain.Models.Order.OrderDTO
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    OrderNumber = o.OrderNumber,
                    Status = o.Status,
                    TotalAmount = o.TotalAmount,
                    DeliveryAddress = o.DeliveryAddress,
                    Comment = o.Comment,
                    CreatedAt = o.CreatedAt,
                    UpdatedAt = o.UpdatedAt
                }).ToList(),
                PopularProducts = popularProducts
            };
        }
    }
}
