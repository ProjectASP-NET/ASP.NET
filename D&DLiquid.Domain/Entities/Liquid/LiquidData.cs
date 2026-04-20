using D_DStore.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_DStore.Domain.Entities.Liquid
{
    public class LiquidData : ProductData
    {
        public int Volume { get; set; }
        public int Nicotine { get; set; }
        public int IceLevel { get; set; }
        public ICollection<FlavorData> Flavors { get; set; } = new List<FlavorData>();
    }
}
