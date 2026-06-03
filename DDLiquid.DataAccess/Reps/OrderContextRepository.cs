using DDLiquid.DataAccess.Interfaces;
using DDLiquid.DataAccess.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDLiquid.DataAccess.Reps
{
    public class OrderContextRepository<T> : IRepository<T> where T : class
    {
        protected readonly OrderDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public OrderContextRepository(OrderDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
            => await _dbSet.ToListAsync();

        public virtual async Task<T?> GetByIdAsync(int id)
            => await _dbSet.FindAsync(id);

        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T?> UpdateAsync(int id, T entity)
        {
            var existing = await _dbSet.FindAsync(id);
            if (existing is null) return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity is null) return false;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}


