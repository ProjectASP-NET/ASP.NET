using DDLiquid.Domain.Entities.References;
using DDLiquid.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDLiquid.Domain.Entities.Order
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

