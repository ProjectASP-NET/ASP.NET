using DDLiquid.DataAccess.Interfaces;
using DDLiquid.DataAccess.Reps;
using DDLiquid.DataAccess.DB;
using DDLiquid.Domain.Entities.BaseProduct.Brand;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDLiquid.DataAccess.Reps
{
    public class BrandRepository : ProductContextRepository<BrandData>, IRepository<BrandData>
    { 
        public BrandRepository(ProductDbContext context) : base(context) { }

        public override async Task<IEnumerable<BrandData>> GetAllAsync()
        {
            return await _dbSet
            .Include(b => b.Country)
            .ToListAsync();
        }
            

        public override async Task<BrandData?> GetByIdAsync(int id)
        {
            return await _dbSet
            .Include(b => b.Country)
            .Include(b => b.Products)
                .ThenInclude(p => p.Images)
            .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}

