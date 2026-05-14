using D_DLiquid.DataAccess.Interfaces;
using D_DLiquid.DataAccess.Reps;
using D_DStore.DataAccess.DB;
using D_DStore.Domain.Entities.Consumable;
using Microsoft.EntityFrameworkCore;

namespace D_DStore.DataAccess.Reps
{
    public class ConsumableRepository : ProductContextRepository<ConsumableData>, IRepository<ConsumableData>
    {
        public ConsumableRepository(ProductDbContext context) : base(context) { }

        public override async Task<IEnumerable<ConsumableData>> GetAllAsync()
        {
            return await _dbSet
                .Include(p => p.Brand)
                    .ThenInclude(b => b!.Country)
                .Include(p => p.Category)
                .Include(p => p.Tags)
                .Include(p => p.Images)
                .ToListAsync();
        }

        public override async Task<ConsumableData?> GetByIdAsync(int id)
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
