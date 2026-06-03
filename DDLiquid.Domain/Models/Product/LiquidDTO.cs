using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDLiquid.Domain.Models.Product;

namespace DDLiquid.Domain.Models.Product
{
    public class LiquidDTO : ProductDTO
    {
        public int Volume { get; set; }
        public int Nicotine { get; set; }
        public int IceLevel { get; set; }

        public ICollection<FlavorDTO> Flavors { get; set; } = new List<FlavorDTO>();
    }
}

