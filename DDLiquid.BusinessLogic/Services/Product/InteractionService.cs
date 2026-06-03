using DDLiquid.DataAccess.Interfaces;
using DDLiquid.BusinessLogic.Interfaces.Product;
using DDLiquid.Domain.Models.Product;

namespace DDLiquid.BusinessLogic.Services.Product
{
    public class InteractionService : IInteractionService
    {
        private readonly IInteractionRepository _repo;

        public InteractionService(IInteractionRepository repo)
        {
            _repo = repo;
        }

        public async Task<ToggleLikeResult> ToggleLikeAsync(int userId, int productId)
            => await _repo.ToggleLikeAsync(userId, productId);

        public async Task<List<int>> GetUserLikedProductIdsAsync(int userId)
            => await _repo.GetUserLikedProductIdsAsync(userId);

        public async Task<ToggleFavoriteResult> ToggleFavoriteAsync(int userId, int productId)
            => await _repo.ToggleFavoriteAsync(userId, productId);

        public async Task<List<int>> GetUserFavoriteProductIdsAsync(int userId)
            => await _repo.GetUserFavoriteProductIdsAsync(userId);
    }
}
