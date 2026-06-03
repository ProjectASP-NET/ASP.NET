namespace DDLiquid.Domain.Models.Order
{
    public class OrderCreateDTO
    {
        public string DeliveryAddress { get; set; } = string.Empty;
        public string? Comment { get; set; }
        public ICollection<OrderItemCreateDTO> Items { get; set; } = new List<OrderItemCreateDTO>();
    }

    public class OrderItemCreateDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
