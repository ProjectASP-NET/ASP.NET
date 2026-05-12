using D_DStore.Domain.Entities.References;
using D_DStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.Domain.Entities.Order
{
    public class OrderData: Refs
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public OrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string DeliveryAddress { get; set; } = string.Empty;
        public string? Comment { get; set; }
        public ICollection<OrderItemData> Items { get; set; } = new List<OrderItemData>();

    }
}
