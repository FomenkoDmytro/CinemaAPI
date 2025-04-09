using EpicVision.Application_BLL.Interfaces;
using EpicVision.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using EpicVision.Application_BLL.DTO.Languages;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet("dictionary")]
        public async Task<IActionResult> GetAllLanguagesDictionary()
        {
            IEnumerable<GetAllLanguagesDictionaryDto> languages;

            try
            {
                languages = await _languageService.GetAllLanguagesDictionary();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok(languages);

        }

        [HttpGet("withMovies")]
        public async Task<IActionResult> GetAllLanguagesWithMovies()
        {
            IEnumerable<GetAllLanguagesWithMoviesDto> languages;

            try
            {
                languages = await _languageService.GetAllLanguagesWithMovies();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok(languages);

        }



        [HttpPost]
        public async Task<IActionResult> AddLanguage([FromBody] AddLanguageDto newLanguage)
        {
            if (newLanguage == null || string.IsNullOrWhiteSpace(newLanguage.LanguageName))
            {
                return BadRequest("Некоректна назва мови");
            }

            try
            {
                await _languageService.Add(newLanguage);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok($"Мову \"{newLanguage.LanguageName}\" додано");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguage(int id)
        {
            try
            {
                await _languageService.Delete(id);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok($"Мову з Id \"{id}\" видалено");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLanguage(int id, [FromBody] UpdateLanguageDto updateLanguage)
        {
            if (updateLanguage == null || string.IsNullOrWhiteSpace(updateLanguage.LanguageName))
            {
                return BadRequest("Некоректна назва мови");
            }

            try
            {
                await _languageService.Update(id, updateLanguage);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok($"Назву мови з Id \"{id}\" оновлено на \"{updateLanguage.LanguageName}\"");
        }
    }
}
