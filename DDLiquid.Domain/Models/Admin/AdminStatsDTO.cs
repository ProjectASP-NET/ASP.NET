using DDLiquid.Domain.Models.Order;

namespace DDLiquid.Domain.Models.Admin
{
    public class AdminStatsDTO
    {
        public int TotalUsers { get; set; }
        public int TotalProducts { get; set; }
        public int TotalOrders { get; set; }
        public decimal Revenue { get; set; }
        public ICollection<OrderStatusCountDTO> OrdersByStatus { get; set; } = new List<OrderStatusCountDTO>();
        public ICollection<OrderDTO> RecentOrders { get; set; } = new List<OrderDTO>();
        public ICollection<PopularProductDTO> PopularProducts { get; set; } = new List<PopularProductDTO>();
    }

    public class OrderStatusCountDTO
    {
        public string Status { get; set; } = string.Empty;
        public int Count { get; set; }
    }

    public class PopularProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int TotalSold { get; set; }
        public decimal Revenue { get; set; }
    }
}
