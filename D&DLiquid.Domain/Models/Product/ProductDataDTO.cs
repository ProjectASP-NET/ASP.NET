using D_DStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_DStore.Domain.Models.Product
{
    public class ProductDataDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Img { get; set; } = string.Empty;
        public ProductStatus Status { get; set; }
        public ProductType Type { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }


    }
}
