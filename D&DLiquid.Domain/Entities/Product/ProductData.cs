using D_DStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D_DStore.Domain.Entities.References;

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
        public string? Brand { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
        public int LikeCount { get; set; }
        public ProductStatus Status { get; set; }
        public ProductType Type { get; set; } 
    }
}
