using D_DStore.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.Domain.Entities.BaseProduct
{
    public class ProductImageData
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public bool IsMain { get; set; }
        public int SortOrder { get; set; }

        public int ProductId { get; set; }
        public ProductData Product { get; set; } = null!;
    }
}
