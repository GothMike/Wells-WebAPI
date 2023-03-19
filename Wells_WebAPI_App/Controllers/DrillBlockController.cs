using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wells_WebAPI.Data.Models;
using Wells_WebAPI.Data.Models.Dto;
using Wells_WebAPI.Data.Services.Interfaces;

namespace Wells_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrillBlockController : ControllerBase
    {
        private readonly IDrillBlockService _drillBlockService;

        public DrillBlockController(IDrillBlockService drillBlockService)
        {
            _drillBlockService = drillBlockService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DrillBlockDto>))]
        public async Task<ActionResult> GetDrillBlocks()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _drillBlockService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(DrillBlockDto))]
        [ProducesResponseType(400)]
        public async Task<ActionResult> GetDrillBlock(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = await _drillBlockService.GetMapEntityByIdAsync(id);

            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<DrillBlock>> CreateDrillBlock([FromBody]DrillBlockDto entityDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

          await _drillBlockService.AddAsync(entityDto);

            return Ok("Успешно создано");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDrillBlock(int id,[FromBody] DrillBlockDto entityDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = await _drillBlockService.GetEntityByIdAsync(id);

            if (entity == null)
                return NotFound();

            if (id != entityDto.Id)
                return BadRequest();

            await _drillBlockService.UpdateAsync(entityDto, entity);

            return Ok("Успешно отредактировано");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrillBlock(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = await _drillBlockService.GetEntityByIdAsync(id);

            if (entity == null)
                return NotFound();

            await _drillBlockService.DeleteAsync(entity);

            return Ok("Успешно удалено");
        }
    }
}
