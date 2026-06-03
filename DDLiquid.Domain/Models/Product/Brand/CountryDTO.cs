using System;
using System.Collections.Generic;
using System.Text;

namespace DDLiquid.Domain.Models.Product.Brand
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }
}
