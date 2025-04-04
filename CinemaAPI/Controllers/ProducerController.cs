using EpicVision.Application_BLL.Interfaces;
using EpicVision.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using EpicVision.Application_BLL.DTO.Producers;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _producerService;

        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpGet("dictionary")]
        public async Task<IActionResult> GetAllProducersDictionary()
        {
            IEnumerable<GetAllProducersDictionaryDto> producers;

            try
            {
                producers = await _producerService.GetAllProducersDictionary();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok(producers);

        }

        [HttpGet("withMovies")]
        public async Task<IActionResult> GetAllProducersWithMovies()
        {
            IEnumerable<GetAllProducersWithMoviesDto> producers;

            try
            {
                producers = await _producerService.GetAllProducersWithMovies();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok(producers);

        }



        [HttpPost]
        public async Task<IActionResult> AddProducer([FromBody] AddProducerDto newProducer)
        {
            if (newProducer == null || string.IsNullOrWhiteSpace(newProducer.FirstName) || string.IsNullOrWhiteSpace(newProducer.LastName))
            {
                return BadRequest("Некоректне І'мя або Прізвище продюсера");
            }

            try
            {
                await _producerService.Add(newProducer);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok($"Продюсера \"{newProducer.FirstName} {newProducer.LastName}\" додано");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducer(int id)
        {
            try
            {
                await _producerService.Delete(id);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok($"Продюсера з Id \"{id}\" видалено");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducer(int id, [FromBody] UpdateProducerDto updateProducer)
        {
            if (updateProducer == null || string.IsNullOrWhiteSpace(updateProducer.FirstName) || string.IsNullOrWhiteSpace(updateProducer.LastName))
            {
                return BadRequest("Некоректне І'мя або Прізвище продюсера");
            }

            try
            {
                await _producerService.Update(id, updateProducer);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok($"Продюсера з Id \"{id}\" оновлено на \"{updateProducer.FirstName} {updateProducer.LastName}\"");
        }
    }
}
