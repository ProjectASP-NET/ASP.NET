using System;
using System.Collections.Generic;
using System.Text;
using D_DStore.Domain.Entities.Product;

namespace D_DStore.Domain.Enums
{
    public class ProductTag
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<ProductData> Products { get; set; } = new List<ProductData>();
    }
}
