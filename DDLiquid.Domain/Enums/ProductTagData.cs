using System;
using System.Collections.Generic;
using System.Text;
using DDLiquid.Domain.Entities.Product;

namespace DDLiquid.Domain.Enums
{
    public class ProductTagData
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<ProductData> Products { get; set; } = new List<ProductData>();
    }
}

