using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_DStore.Domain.Models.Product
{
    public class LiquidDTO : ProductDTO
    {
        public int Volume { get; set; }
        public string Flavors { get; set; } = string.Empty;
        public int Nicotine { get; set; }
        public int IceLevel { get; set; }
    }
}
