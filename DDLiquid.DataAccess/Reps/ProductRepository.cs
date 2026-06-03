using DDLiquid.DataAccess.Interfaces;
using DDLiquid.DataAccess.Reps;
using DDLiquid.DataAccess.DB;
using DDLiquid.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDLiquid.DataAccess.Reps
{
    public class ProductRepository : ProductContextRepository<ProductData>, IRepository<ProductData>
    {
        public ProductRepository(ProductDbContext context) : base(context)  { }
        public override async Task<IEnumerable<ProductData>> GetAllAsync()
        {
            return await _dbSet
            .Include(p => p.Brand)
            .ThenInclude(b => b!.Country)
            .Include(p => p.Category)
            .Include(p => p.Tags)
            .Include(p => p.Images)
            .ToListAsync();
        }
        public override async Task<ProductData?> GetByIdAsync(int id)
        {
            return await _dbSet
           .Include(p => p.Brand)
           .ThenInclude(b => b!.Country)
           .Include(p => p.Category)
           .Include(p => p.Tags)
           .Include(p => p.Images)
           .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}

