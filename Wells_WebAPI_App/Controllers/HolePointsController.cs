using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wells_WebAPI.Data.Models.Dto;
using Wells_WebAPI.Data.Services.Interfaces;

namespace Wells_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolePointsController : ControllerBase
    {
        private readonly IHolePointsService _holePointsService;

        public HolePointsController(IHolePointsService holePointsService)
        {
            _holePointsService = holePointsService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<HolePointsDto>))]
        public async Task<ActionResult> GetHolePoints()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _holePointsService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(HolePointsDto))]
        [ProducesResponseType(400)]
        public async Task<ActionResult> GetHolePoints(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = await _holePointsService.GetMapEntityByIdAsync(id);

            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<HolePointsDto>> CreateHolePoints([FromBody] HolePointsDto entityDto, [FromQuery] int holeId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var drillBlock = await _holePointsService.GetHole(holeId);

            if (drillBlock == null)
                return NotFound();

            await _holePointsService.AddAsync(entityDto, drillBlock);

            return Ok("Успешно создано");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHolePoints(int id, [FromBody] HolePointsDto entityDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = await _holePointsService.GetEntityByIdAsync(id);

            if (entity == null)
                return NotFound();

            if (id != entityDto.Id)
                return BadRequest();

            await _holePointsService.UpdateAsync(entityDto, entity);

            return Ok("Успешно отредактировано");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHolePoints(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = await _holePointsService.GetEntityByIdAsync(id);

            if (entity == null)
                return NotFound();

           await _holePointsService.DeleteAsync(entity);

            return Ok("Успешно удалено");
        }
    }
}
