using EpicVision.Application_BLL.Interfaces;
using EpicVision.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using EpicVision.Application_BLL.DTO.Ganres;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudienceController : ControllerBase
    {
        private readonly IGanreService _ganreService;

        public AudienceController(IGanreService ganreService)
        {
            _ganreService = ganreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGanresDictionary()
        {
            IEnumerable<GetAllGanresDictionaryDto> ganres;
            try
            {
                ganres = await _ganreService.GetAllGanresDictionary();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok(ganres);

        }

        [HttpPost]
        public async Task<IActionResult> AddGanre([FromBody] AddGanreDto newGanre)
        {
            if (newGanre == null || string.IsNullOrWhiteSpace(newGanre.Name))
            {
                return BadRequest("Некоректна назва жанру");
            }

            try
            {
                await _ganreService.Add(newGanre);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok($"Жанр \"{newGanre.Name}\" додано");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGanre(int id)
        {
            try
            {
                await _ganreService.Delete(id);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok($"Жанр з Id \"{id}\" видалено");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGanre(int id, [FromBody] UpdateGanreDto updateGanre)
        {
            if (updateGanre == null || string.IsNullOrWhiteSpace(updateGanre.Name))
            {
                return BadRequest("Некоректна назва жанру");
            }

            try
            {
                await _ganreService.Update(id, updateGanre);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok($"Назву жанру з Id \"{id}\" оновлено на \"{updateGanre.Name}\"");
        }
    }
}
