using System;
using System.Collections.Generic;
using System.Text;

namespace DDLiquid.Domain.Entities.BaseProduct.Brand
{
    public class CountryData
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

        public ICollection<BrandData> Brands { get; set; } = new List<BrandData>();
    }
}

