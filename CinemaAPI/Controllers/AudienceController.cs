using EpicVision.Application_BLL.Interfaces;
using EpicVision.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using EpicVision.Application_BLL.DTO.Audiences;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudienceController : ControllerBase
    {
        private readonly IAudienceService _audienceService;

        public AudienceController(IAudienceService audienceService)
        {
            _audienceService = audienceService;
        }

        [HttpGet("dictionary")]
        public async Task<IActionResult> GetAllAudiencesDictionary()
        {
            IEnumerable<GetAllAudiencesDictionaryDto> audiences;

            try
            {
                audiences = await _audienceService.GetAllAudiencesDictionary();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok(audiences);

        }

        [HttpGet("withMovies")]
        public async Task<IActionResult> GetAllAudiencesWithMovies()
        {
            IEnumerable<GetAllAudiencesWithMoviesDto> audiences;

            try
            {
                audiences = await _audienceService.GetAllAudiencesWithMovies();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok(audiences);

        }



        [HttpPost]
        public async Task<IActionResult> AddAudience([FromBody] AddAudienceDto newAudience)
        {
            if (newAudience == null || string.IsNullOrWhiteSpace(newAudience.Category))
            {
                return BadRequest("Некоректна назва аудиторії");
            }

            try
            {
                await _audienceService.Add(newAudience);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok($"Аудиторію \"{newAudience.Category}\" додано");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAudience(int id)
        {
            try
            {
                await _audienceService.Delete(id);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok($"Аудиторію з Id \"{id}\" видалено");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAudience(int id, [FromBody] UpdateAudienceDto updateAudience)
        {
            if (updateAudience == null || string.IsNullOrWhiteSpace(updateAudience.Category))
            {
                return BadRequest("Некоректна назва аудиторії");
            }

            try
            {
                await _audienceService.Update(id, updateAudience);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok($"Назву аудиторії з Id \"{id}\" оновлено на \"{updateAudience.Category}\"");
        }
    }
}
