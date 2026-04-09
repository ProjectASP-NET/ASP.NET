using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using D_DStore.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace D_DStore.DataAccess.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<LiquidData> Liquids { get; set; }
        public DbSet<VapeData> Vapes { get; set; }
        public DbSet<ConsumableData> Consumables { get; set; }
    }
}