using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D_DStore.Domain.Entities.Product;

namespace D_DStore.Domain.Entities.Vape
{
    public class VapeData : ProductData
{
    public int BatteryCapacity { get; set; }
    public int MaxPower { get; set; }
    public string Color { get; set; } = string.Empty;
    public decimal TankCapacity { get; set; }
    public decimal CoilResistance { get; set; }
}
}
