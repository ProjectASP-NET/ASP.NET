using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DDLiquid.BusinessLogic.Interfaces.Auth;
using DDLiquid.Domain.Models.Auth;

namespace DDLiquid.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var user = await _userService.GetByIdAsync(userId);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserUpdateData data)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var updated = await _userService.UpdateAsync(id, data);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpPut("{id}/role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] DDLiquid.Domain.Models.Auth.UserUpdateData data)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!data.RoleId.HasValue)
                return BadRequest(new { Message = "RoleId is required" });

            var updated = await _userService.UpdateRoleAsync(id, data.RoleId.Value);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _userService.DeleteAsync(id) ? NoContent() : NotFound();
        }
    }
}

