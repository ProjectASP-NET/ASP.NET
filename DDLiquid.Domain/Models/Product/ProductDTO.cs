using DDLiquid.Domain.Enums;
using DDLiquid.Domain.Models.Product.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDLiquid.Domain.Models.Product
{
      public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int LikeCount { get; set; }
        public int? BrandId { get; set; }
        public BrandDTO? Brand { get; set; }
        public int? CategoryId { get; set; }
        public CategoryDTO? Category { get; set; }
        public ICollection<TagDTO> Tags { get; set; } = new List<TagDTO>();
        public ICollection<ProductImageDTO> Images { get; set; } = new List<ProductImageDTO>();
    }
}

