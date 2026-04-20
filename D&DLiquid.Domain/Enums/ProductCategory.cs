using D_DStore.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.Domain.Enums
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? IconUrl { get; set; }

        public ICollection<ProductData> Products { get; set; } = new List<ProductData>();
    }
}
