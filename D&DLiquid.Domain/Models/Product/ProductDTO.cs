using D_DStore.Domain.Enums;
using D_DStore.Domain.Models.Product.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_DStore.Domain.Models.Product
{
      public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Img { get; set; } = string.Empty;
        public ProductStatus Status { get; set; }
        public ProductType Type { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public BrandDTO? Brand { get; set; }
        public CategoryDTO? Category { get; set; }
        public ICollection<TagDTO> Tags { get; set; } = new List<TagDTO>();
    }
}
