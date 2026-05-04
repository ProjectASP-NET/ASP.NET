using D_DLiquid.DataAccess.Interfaces;
using D_DLiquid.DataAccess.Reps;
using D_DStore.DataAccess.DB;
using D_DStore.Domain.Entities.BaseProduct.Brand;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.DataAccess.Reps
{
    public class BrandRepository : Repository<BrandData>, IRepository<BrandData>
    { 
        public BrandRepository(AppDbContext context) : base(context) { }

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
            .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
