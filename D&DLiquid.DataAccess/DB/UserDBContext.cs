using D_DStore.Domain.Entities.References;
using D_DStore.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.DataAccess.DB
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        public DbSet<UserData> Users { get; set; }
        public DbSet<RoleData> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserData>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserData>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<UserData>()
                .HasIndex(u => u.NickName)
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