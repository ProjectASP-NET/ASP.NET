using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DDLiquid.BusinessLogic.Interfaces.Auth;
using DDLiquid.Domain.Models.Auth;

namespace DDLiquid.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterData data)
        {
            try
            {
                var result = await _userService.RegisterAsync(data);
                return Created($"api/user/{result.User.Id}", result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginData data)
        {
            var result = await _userService.LoginAsync(data);
            return result == null
                ? Unauthorized(new { Message = "Invalid login or password" })
                : Ok(result);
        }

        [HttpPost("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordData data)
        {
            var userId = int.Parse(User.FindFirstValue(System.Security.Claims.ClaimTypes.NameIdentifier)!);
            var success = await _userService.ChangePasswordAsync(userId, data.CurrentPassword, data.NewPassword);
            return success
                ? Ok(new { Message = "Password changed successfully" })
                : BadRequest(new { Message = "Current password is incorrect" });
        }
    }
}

