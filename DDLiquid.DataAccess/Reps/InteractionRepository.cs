using DDLiquid.DataAccess.DB;
using DDLiquid.DataAccess.Interfaces;
using DDLiquid.Domain.Entities.Product;
using DDLiquid.Domain.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace DDLiquid.DataAccess.Reps
{
    public class InteractionRepository : IInteractionRepository
    {
        private readonly ProductDbContext _context;

        public InteractionRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<ToggleLikeResult> ToggleLikeAsync(int userId, int productId)
        {
            var existing = await _context.Set<ProductLikeData>()
                .FirstOrDefaultAsync(l => l.UserId == userId && l.ProductId == productId);

            if (existing is not null)
            {
                _context.Set<ProductLikeData>().Remove(existing);
                var product = await _context.Products.FindAsync(productId);
                if (product is not null)
                {
                    product.LikeCount = Math.Max(0, product.LikeCount - 1);
                }
                await _context.SaveChangesAsync();
                return new ToggleLikeResult { IsLiked = false, LikeCount = product?.LikeCount ?? 0 };
            }

            var like = new ProductLikeData { UserId = userId, ProductId = productId };
            await _context.Set<ProductLikeData>().AddAsync(like);
            var prod = await _context.Products.FindAsync(productId);
            if (prod is not null)
            {
                prod.LikeCount++;
            }
            await _context.SaveChangesAsync();
            return new ToggleLikeResult { IsLiked = true, LikeCount = prod?.LikeCount ?? 0 };
        }

        public async Task<List<int>> GetUserLikedProductIdsAsync(int userId)
        {
            return await _context.Set<ProductLikeData>()
                .Where(l => l.UserId == userId)
                .Select(l => l.ProductId)
                .ToListAsync();
        }

        public async Task<ToggleFavoriteResult> ToggleFavoriteAsync(int userId, int productId)
        {
            var existing = await _context.Set<ProductFavoriteData>()
                .FirstOrDefaultAsync(f => f.UserId == userId && f.ProductId == productId);

            if (existing is not null)
            {
                _context.Set<ProductFavoriteData>().Remove(existing);
                await _context.SaveChangesAsync();
                return new ToggleFavoriteResult { IsFavorited = false };
            }

            var fav = new ProductFavoriteData { UserId = userId, ProductId = productId };
            await _context.Set<ProductFavoriteData>().AddAsync(fav);
            await _context.SaveChangesAsync();
            return new ToggleFavoriteResult { IsFavorited = true };
        }

        public async Task<List<int>> GetUserFavoriteProductIdsAsync(int userId)
        {
            return await _context.Set<ProductFavoriteData>()
                .Where(f => f.UserId == userId)
                .Select(f => f.ProductId)
                .ToListAsync();
        }
    }
}
