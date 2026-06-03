using DDLiquid.Domain.Entities.BaseProduct.Brand;
using DDLiquid.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDLiquid.Domain.Models.Product.Brand
{
    public class BrandDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
        public CountryDTO? Country { get; set; }
        public ICollection<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}
