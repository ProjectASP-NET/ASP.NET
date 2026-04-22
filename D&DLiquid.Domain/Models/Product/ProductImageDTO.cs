using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.Domain.Models.Product
{
    public class ProductImageDTO
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public bool IsMain { get; set; }
        public int SortOrder { get; set; }

    }
}
