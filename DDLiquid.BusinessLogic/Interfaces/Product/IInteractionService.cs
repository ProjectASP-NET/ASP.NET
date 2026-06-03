using DDLiquid.Domain.Models.Product;

namespace DDLiquid.BusinessLogic.Interfaces.Product
{
    public interface IInteractionService
    {
        Task<ToggleLikeResult> ToggleLikeAsync(int userId, int productId);
        Task<List<int>> GetUserLikedProductIdsAsync(int userId);
        Task<ToggleFavoriteResult> ToggleFavoriteAsync(int userId, int productId);
        Task<List<int>> GetUserFavoriteProductIdsAsync(int userId);
    }
}
