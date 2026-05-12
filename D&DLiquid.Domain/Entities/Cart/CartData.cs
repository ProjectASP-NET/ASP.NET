using D_DStore.Domain.Entities.References;
using D_DStore.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.Domain.Entities.Cart
{
    public class CartData:Refs
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ICollection<CartItemData> Items { get; set; } = new List<CartItemData>();
    }
}
