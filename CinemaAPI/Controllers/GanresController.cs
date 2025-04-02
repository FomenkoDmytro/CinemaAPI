using EpicVision.Application_BLL.Interfaces;
using EpicVision.Application_BLL.DTO;
using EpicVision.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> AddGanre([FromBody] GetAllGanresDto newGanre)
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


    }
}
