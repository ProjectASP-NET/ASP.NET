using D_DStore.Domain.Entities.References;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.Domain.Entities.Cart
{
    public class CartItemData:Refs
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public CartData Cart { get; set; } = null!;
        public int ProductId { get; set; }
        public int Quantity { get; set; } 
    }
}
