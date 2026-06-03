using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DDLiquid.BusinessLogic.Interfaces.Admin;

namespace DDLiquid.API.Controllers
{
    [Route("api/admin")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("stats")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetStats()
        {
            var stats = await _adminService.GetStatsAsync();
            return Ok(stats);
        }
    }
}
