using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_DStore.Domain.Models.Product
{
    public class VapeDTO : ProductDataDTO
    {
        public int BatteryCapacity { get; set; }
        public int MaxPower { get; set; }
        public string Color { get; set; } = string.Empty;
        public decimal TankCapacity { get; set; }
        public decimal CoilResistance { get; set; }
    }
}
