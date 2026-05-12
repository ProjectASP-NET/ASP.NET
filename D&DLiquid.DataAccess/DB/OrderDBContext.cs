using D_DStore.Domain.Entities.Cart;
using D_DStore.Domain.Entities.Order;
using D_DStore.Domain.Entities.References;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.DataAccess.DB
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }
        public DbSet<OrderData> Orders { get; set; }
        public DbSet<OrderItemData> OrderItems { get; set; }
        public DbSet<CartData> Cart { get; set; }
        public DbSet<CartItemData> CartItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderData>()
                .HasMany(o => o.Items)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<OrderData>()
                .HasIndex(o => o.UserId);
            modelBuilder.Entity<OrderData>()
                .HasIndex(o => o.OrderNumber)
                .IsUnique();
            modelBuilder.Entity<OrderItemData>()
                .HasIndex(oi => oi.ProductId);
            modelBuilder.Entity<CartData>()
                .HasMany(c => c.Items)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CartData>()
                .HasIndex(c => c.UserId)
                .IsUnique();
            modelBuilder.Entity<CartItemData>()
                .HasIndex(ci => ci.ProductId);
            modelBuilder.Entity<CartItemData>()
                .HasIndex(ci => new { ci.CartId, ci.ProductId })
                .IsUnique();
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