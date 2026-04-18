using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using D_DStore.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
//Для себя пока оставил команды по работе с БД,по концу их не будет.
//dotnet ef migrations add
//dotnet ef database update --startup-project ../Control

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