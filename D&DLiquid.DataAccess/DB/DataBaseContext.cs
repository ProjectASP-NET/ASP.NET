using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using D_DStore.Domain.Entities.Consumable;
using D_DStore.Domain.Entities.Liquid;
using D_DStore.Domain.Entities.Vape;
using Microsoft.EntityFrameworkCore;
using D_DStore.Domain.Entities.BaseProduct.Brand;
using D_DStore.Domain.Enums;
using D_DStore.Domain.Entities.Product;
using D_DStore.Domain.Entities.References;
using D_DStore.Domain.Entities.BaseProduct;
//Для себя пока оставил команды по работе с БД,по концу их не будет.
//dotnet ef migrations add Relations --startup-project ../Control
//dotnet ef database update --startup-project ../Control
namespace D_DStore.DataAccess.DB
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
            public DbSet<ProductData> Products { get; set; }
            public DbSet<LiquidData> Liquids { get; set; }
            public DbSet<VapeData> Vapes { get; set; }
            public DbSet<ConsumableData> Consumables { get; set; }
            public DbSet<FlavorData> Flavors { get; set; }
            public DbSet<BrandData> Brands { get; set; }
            public DbSet<ProductCategory> Categories { get; set; }
            public DbSet<ProductTag> Tags { get; set; }
            public DbSet<CountryData> Countries { get; set; }
            public DbSet<ProductImageData> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<ProductImageData>()
                    .HasOne(pi => pi.Product)
                    .WithMany(p => p.Images)
                    .HasForeignKey(pi => pi.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<LiquidData>()
                    .HasMany(l => l.Flavors)
                    .WithMany(f => f.Liquids)
                    .UsingEntity("LiquidFlavors");

                modelBuilder.Entity<ProductData>()
                    .HasMany(p => p.Tags)
                    .WithMany(t => t.Products)
                    .UsingEntity("ProductTags");

                modelBuilder.Entity<ProductData>()
                    .HasOne(p => p.Brand)
                    .WithMany(b => b.Products)
                    .HasForeignKey(p => p.BrandId)
                    .OnDelete(DeleteBehavior.SetNull);

                modelBuilder.Entity<ProductData>()
                    .HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull);

                modelBuilder.Entity<BrandData>()
                    .HasOne(b => b.Country)
                    .WithMany(c => c.Brands)
                    .HasForeignKey(b => b.CountryId)
                    .OnDelete(DeleteBehavior.SetNull);
            }

            public override async Task<int> SaveChangesAsync(CancellationToken ct = default)
            {
                var entries = ChangeTracker.Entries()
                    .Where(e => e.Entity is Refs && e.State == EntityState.Modified);

                foreach (var entry in entries)
                    ((Refs)entry.Entity).UpdatedAt = DateTime.UtcNow;

                return await base.SaveChangesAsync(ct);
            }
        }
    }