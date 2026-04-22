using D_DStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D_DStore.Domain.Entities.References;
using D_DStore.Domain.Entities;
using D_DStore.Domain.Entities.BaseProduct.Brand;
using D_DStore.Domain.Entities.BaseProduct;


namespace D_DStore.Domain.Entities.Product
{
    public class ProductData : Refs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50), MinLength(5)]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int LikeCount { get; set; }
        public ProductStatus Status { get; set; }
        public ProductType Type { get; set; } 
        public int? BrandId { get; set; }
        public BrandData? Brand { get; set; }
        public int? CategoryId { get; set; }
        public ProductCategory? Category { get; set; }
        public ICollection<ProductTag> Tags { get; set; } = new List<ProductTag>();
        public ICollection<ProductImageData> Images { get; set; } = new List<ProductImageData>();
    }
}
