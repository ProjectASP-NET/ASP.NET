using Microsoft.AspNetCore.Mvc;
using D_DStore.BusinessLogic.Interfaces;
using D_DStore.Domain.Models.BaseActions;
using Microsoft.OpenApi.MicrosoftExtensions;

namespace Control.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TDTO> : ControllerBase
        where TDTO : class
    {
        private readonly IBaseService<TDTO> _service;
        private readonly string _entityName;

        protected BaseController(IBaseService<TDTO> service, string entityName)
        {
            _service = service;
            _entityName = entityName;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result is null)
                return NotFound(new Response<TDTO> { Success = false, Message = ErrorMassage.NotFound(_entityName, id) });
            return Ok(new Response<TDTO> { 
                Success = true, 
                Data = result,
                Message = SuccessMassage.GetById(_entityName, id)
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.GetType().GetProperty("Id")?.GetValue(created) }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TDTO dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            if (result is null)
                return NotFound(new Response<TDTO> { Success = false, Message = ErrorMassage.NotFound(_entityName, id) });
            return Ok(
           new Response<TDTO> { Success = true , Message = SuccessMassage.Edited(_entityName, id)});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound(new Response<TDTO> { Success = false, Message = ErrorMassage.NotFound(_entityName, id) });
            return Ok(new Response<TDTO> { Success = true, Message = SuccessMassage.Deleted(_entityName, id) });
        }
    }
}