using EpicVision.Application_BLL.Interfaces;
using EpicVision.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using EpicVision.Application_BLL.DTO.Actors;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet("dictionary")]
        public async Task<IActionResult> GetAllActorsDictionary()
        {
            IEnumerable<GetAllActorsDictionaryDto> actors;

            try
            {
                actors = await _actorService.GetAllActorsDictionary();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok(actors);

        }

        [HttpGet("withMovies")]
        public async Task<IActionResult> GetAllActorsWithMovies()
        {
            IEnumerable<GetAllActorsWithMoviesDto> actors;

            try
            {
                actors = await _actorService.GetAllActorsWithMovies();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok(actors);

        }



        [HttpPost]
        public async Task<IActionResult> AddActor([FromBody] AddActorDto newActor)
        {
            if (newActor == null || string.IsNullOrWhiteSpace(newActor.FirstName) || string.IsNullOrWhiteSpace(newActor.LastName))
            {
                return BadRequest("Некоректне І'мя або Прізвище актора");
            }

            try
            {
                await _actorService.Add(newActor);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok($"Актора \"{newActor.FirstName} {newActor.LastName}\" додано");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            try
            {
                await _actorService.Delete(id);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok($"Актора з Id \"{id}\" видалено");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActor(int id, [FromBody] UpdateActorDto updateActor)
        {
            if (updateActor == null || string.IsNullOrWhiteSpace(updateActor.FirstName) || string.IsNullOrWhiteSpace(updateActor.LastName))
            {
                return BadRequest("Некоректне І'мя або Прізвище актора");
            }

            try
            {
                await _actorService.Update(id, updateActor);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok($"Актора з Id \"{id}\" оновлено на \"{updateActor.FirstName} {updateActor.LastName}\"");
        }
    }
}
