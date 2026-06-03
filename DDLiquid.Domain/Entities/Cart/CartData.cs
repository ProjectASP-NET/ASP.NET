using DDLiquid.Domain.Entities.References;
using DDLiquid.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDLiquid.Domain.Entities.Cart
{
    public class CartData:Refs
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ICollection<CartItemData> Items { get; set; } = new List<CartItemData>();
    }
}

