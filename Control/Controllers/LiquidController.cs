using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using D_DStore.BusinessLogic.Interfaces;
using D_DStore.Domain.Models.BaseActions;
using D_DStore.Domain.Models.Product;

namespace Control.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiquidsController : ControllerBase
    {
        private readonly ILiquidService _service;

        public LiquidsController(ILiquidService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result is null)
                return NotFound(new Response { Success = false, Message = ErrorMassage.NotFound("Liquid", id) });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LiquidDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LiquidDTO dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            if (result is null)
                return NotFound(new Response { Success = false, Message = ErrorMassage.NotFound("Liquid", id) });
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound(new Response { Success = false, Message = ErrorMassage.NotFound("Liquid", id) });
            return Ok(new Response { Success = true, Message = SuccessMassage.Deleted("Liquid", id) });
        }
    }
}
