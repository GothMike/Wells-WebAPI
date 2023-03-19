using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wells_WebAPI.Data.Models.Dto;
using Wells_WebAPI.Data.Models;
using Wells_WebAPI.Data.Services;
using Wells_WebAPI.Data.Services.Interfaces;

namespace Wells_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoleController : ControllerBase
    {
        private readonly IHoleService _holeService;

        public HoleController(IHoleService holeService)
        {
            _holeService = holeService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<HoleDto>))]
        public async Task<ActionResult> GetHoles()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _holeService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(HoleDto))]
        [ProducesResponseType(400)]
        public async Task<ActionResult> GetHole(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = await _holeService.GetMapEntityByIdAsync(id);

            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<HoleDto>> CreateHole([FromBody]HoleDto entityDto,[FromQuery] int drillBlockId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var drillBlock = await _holeService.GetDrillBlock(drillBlockId);
            if (drillBlock == null)
                return NotFound();

            await _holeService.AddAsync(entityDto, drillBlock);

            return Ok("Успешно создано");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHole(int id, [FromBody] HoleDto entityDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = await _holeService.GetEntityByIdAsync(id);

            if (entity == null)
                return NotFound();

            if (id != entityDto.Id)
                return BadRequest();

            _holeService.UpdateAsync(entityDto, entity);

            return Ok("Успешно отредактировано");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHole(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = await _holeService.GetEntityByIdAsync(id);

            if (entity == null)
                return NotFound();

            _holeService.DeleteAsync(entity);

            return Ok("Успешно удалено");
        }
    }
}
