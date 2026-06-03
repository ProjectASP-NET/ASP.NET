using DDLiquid.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace DDLiquid.Domain.Entities.BaseProduct.Brand
{
    public class BrandData
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }

        public int? CountryId { get; set; }
        public CountryData? Country { get; set; }

        public ICollection<ProductData> Products { get; set; } = new List<ProductData>();
    }
}

