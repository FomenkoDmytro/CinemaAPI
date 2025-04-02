using EpicVision.Application_BLL.Interfaces;
using EpicVision.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using EpicVision.Application_BLL.DTO.Ganres;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GanresController : ControllerBase
    {
        private readonly IGanreService _ganreService;

        public GanresController(IGanreService ganreService)
        {
            _ganreService = ganreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGanres()
        {
            IEnumerable<GetAllGanresDto> ganres = null;
            try
            {
                ganres = await _ganreService.GetAllGanres();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
                throw new Exception(ex.Message);
            }

            return Ok($"Жанр \"{newGanre.Name}\" додано");

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGanre([FromBody] DeleteGanreDto deleteGanre)
        {
            if (deleteGanre == null)
            {
                return BadRequest("Некоректний id для видалення жанру");
            }

            try
            {
                await _ganreService.Delete(deleteGanre.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Ok($"Жанр з Id \"{deleteGanre.Id}\" видалено");
        }


    }
}
