using DDLiquid.Domain.Enums;

namespace DDLiquid.Domain.Models.Order
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public OrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string DeliveryAddress { get; set; } = string.Empty;
        public string? Comment { get; set; }
        public ICollection<OrderItemDTO> Items { get; set; } = new List<OrderItemDTO>();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
