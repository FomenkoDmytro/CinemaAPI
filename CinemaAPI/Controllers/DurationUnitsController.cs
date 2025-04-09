using EpicVision.Application_BLL.DTO.DurationUnits;
using EpicVision.Application_BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DurationUnitsController : ControllerBase
    {
        private readonly IDurationUnitService _durationUnitService;

        public DurationUnitsController(IDurationUnitService durationUnitService)
        {
            _durationUnitService = durationUnitService;
        }

        [HttpGet("dictionary")]
        public async Task<IActionResult> GetAllDurationUnitsDictionary()
        {
            IEnumerable<GetAllDurationUnitsDictionaryDto> durationUnits;

            try
            {
                durationUnits = await _durationUnitService.GetAllDurationUnitsDictionary();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok(durationUnits);

        }

        [HttpPost]
        public async Task<IActionResult> AddDurationUnit([FromBody] AddDurationUnitDto newDurationUnit)
        {
            if (newDurationUnit == null || string.IsNullOrWhiteSpace(newDurationUnit.ShortName) || string.IsNullOrWhiteSpace(newDurationUnit.FullName))
            {
                return BadRequest("Некоректна назва одиниці виміру часу");
            }

            try
            {
                await _durationUnitService.Add(newDurationUnit);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok($"Одиницю виміру часу \"{newDurationUnit.FullName}\" додано");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDurationUnit(int id)
        {
            try
            {
                await _durationUnitService.Delete(id);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok($"Одиницю виміру часу з Id \"{id}\" видалено");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDurationUnit(int id, [FromBody] UpdateDurationUnitDto updateDurationUnit)
        {
            if (updateDurationUnit == null || string.IsNullOrWhiteSpace(updateDurationUnit.ShortName) || string.IsNullOrWhiteSpace(updateDurationUnit.FullName))
            {
                return BadRequest("Некоректна назва одиниці виміру часу");
            }

            try
            {
                await _durationUnitService.Update(id, updateDurationUnit);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok($"Назву одиниці виміру часу з Id \"{id}\" оновлено на \"{updateDurationUnit.FullName}\"");
        }
    }
}
