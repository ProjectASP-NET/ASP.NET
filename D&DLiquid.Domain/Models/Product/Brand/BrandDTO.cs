using D_DStore.Domain.Entities.BaseProduct.Brand;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.Domain.Models.Product.Brand
{
    public class BrandDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
        public CountryDTO? Country { get; set; }
    }
}