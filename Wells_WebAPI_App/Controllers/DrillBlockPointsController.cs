using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wells_WebAPI.Data.Models.Dto;
using Wells_WebAPI.Data.Services.Interfaces;

namespace Wells_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrillBlockPointsController : ControllerBase
    {
        private readonly IDrillBlockPointsService _drillBlockPointsService;

        public DrillBlockPointsController(IDrillBlockPointsService drillBlockPointsService)
        {
            _drillBlockPointsService = drillBlockPointsService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DrillBlockPointsDto>))]
        public async Task<ActionResult> GetDrillBlockPoints()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _drillBlockPointsService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(DrillBlockPointsDto))]
        [ProducesResponseType(400)]
        public async Task<ActionResult> GetDrillBlockPoints(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = await _drillBlockPointsService.GetMapEntityByIdAsync(id);

            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<DrillBlockPointsDto>> CreateDrillBlockPoints([FromBody] DrillBlockPointsDto entityDto, [FromQuery] int drillBlockId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var drillBlock = await _drillBlockPointsService.GetDrillBlock(drillBlockId);

            if (drillBlock == null)
                return NotFound();

            await _drillBlockPointsService.AddAsync(entityDto, drillBlock);

            return Ok("Успешно создано");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDrillBlockPoints(int id, [FromBody] DrillBlockPointsDto entityDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = await _drillBlockPointsService.GetEntityByIdAsync(id);

            if (entity == null)
                return NotFound();

            if (id != entityDto.Id)
                return BadRequest();

            await _drillBlockPointsService.UpdateAsync(entityDto, entity);

            return Ok("Успешно отредактировано");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrillBlockPoints(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = await _drillBlockPointsService.GetEntityByIdAsync(id);

            if (entity == null)
                return NotFound();

            await _drillBlockPointsService.DeleteAsync(entity);

            return Ok("Успешно удалено");
        }
    }
}
