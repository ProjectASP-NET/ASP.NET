using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.Domain.Entities.Product
{
    public class FlavorData
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<LiquidData> Liquids { get; set; } = new List<LiquidData>();
    }
}
