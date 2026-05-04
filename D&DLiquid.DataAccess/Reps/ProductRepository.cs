using D_DLiquid.DataAccess.Interfaces;
using D_DLiquid.DataAccess.Reps;
using D_DStore.DataAccess.DB;
using D_DStore.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.DataAccess.Reps
{
    public class ProductRepository : Repository<ProductData>, IRepository<ProductData>
    {
        public ProductRepository(AppDbContext context) : base(context)  { }
        public override async Task<IEnumerable<ProductData>> GetAllAsync()
        {
            return await _dbSet
            .Include(p => p.Brand)
            .Include(p => p.Category)
            .Include(p => p.Tags)
            .Include(p => p.Images)
            .ToListAsync();
        }
        public override async Task<ProductData?> GetByIdAsync(int id)
        {
            return await _dbSet
           .Include(p => p.Brand)
           .Include(p => p.Category)
           .Include(p => p.Tags)
           .Include(p => p.Images)
           .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
