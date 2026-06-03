using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DDLiquid.BusinessLogic.Interfaces.Product;

namespace DDLiquid.API.Controllers
{
    [Route("api/interaction")]
    [ApiController]
    [Authorize]
    public class InteractionController : ControllerBase
    {
        private readonly IInteractionService _service;

        public InteractionController(IInteractionService service)
        {
            _service = service;
        }

        private int GetUserId()
            => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        [HttpPost("product/{productId}/like")]
        public async Task<IActionResult> ToggleLike(int productId)
        {
            var result = await _service.ToggleLikeAsync(GetUserId(), productId);
            return Ok(result);
        }

        [HttpPost("product/{productId}/favorite")]
        public async Task<IActionResult> ToggleFavorite(int productId)
        {
            var result = await _service.ToggleFavoriteAsync(GetUserId(), productId);
            return Ok(result);
        }

        [HttpGet("me/likes")]
        public async Task<IActionResult> GetMyLikes()
        {
            var ids = await _service.GetUserLikedProductIdsAsync(GetUserId());
            return Ok(ids);
        }

        [HttpGet("me/favorites")]
        public async Task<IActionResult> GetMyFavorites()
        {
            var ids = await _service.GetUserFavoriteProductIdsAsync(GetUserId());
            return Ok(ids);
        }
    }
}
