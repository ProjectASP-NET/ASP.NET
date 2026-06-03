using DDLiquid.DataAccess.Interfaces;
using DDLiquid.DataAccess.Reps;
using DDLiquid.DataAccess.DB;
using DDLiquid.Domain.Entities.Liquid;
using Microsoft.EntityFrameworkCore;

namespace DDLiquid.DataAccess.Reps
{
    public class LiquidRepository : ProductContextRepository<LiquidData>, IRepository<LiquidData>
    {
        public LiquidRepository(ProductDbContext context) : base(context) { }

        public override async Task<IEnumerable<LiquidData>> GetAllAsync()
        {
            return await _dbSet
                .Include(p => p.Brand)
                    .ThenInclude(b => b!.Country)
                .Include(p => p.Category)
                .Include(p => p.Tags)
                .Include(p => p.Images)
                .Include(p => p.Flavors)
                .ToListAsync();
        }

        public override async Task<LiquidData?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Brand)
                    .ThenInclude(b => b!.Country)
                .Include(p => p.Category)
                .Include(p => p.Tags)
                .Include(p => p.Images)
                .Include(p => p.Flavors)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}

