using DDLiquid.Domain.Entities.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDLiquid.Domain.Entities.Order
{
    public class OrderItemData:Refs
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderData Order { get; set; } = null!;
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}

