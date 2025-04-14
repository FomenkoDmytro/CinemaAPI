using EpicVision.Application_BLL.DTO.Movies;
using EpicVision.Application_BLL.Interfaces;
using EpicVision.Application_BLL.Services;
using EpicVision.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // Получить все фильмы
        [HttpGet]
        /*public IActionResult GetAll()
        {
            return Ok(_movieService.GetAllMovies());
        }*/

        [HttpGet("{dateTime}")]
        public IActionResult GetMoviesFromDate(DateTime dateTime)
        {
            var startDate = DateOnly.FromDateTime(dateTime);
            var startTime = TimeOnly.FromDateTime(dateTime);

            var movies = _movieService.GetMoviesFromDate(startDate, startTime);
            return Ok(movies);
        }

        // Получить фильм по ID
        /*[HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = _movieService.GetMovieById(id);
            return movie != null ? Ok(movie) : NotFound();
        }*/

        // Создать новый фильм
        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] AddMovieDto newMovie)
        {
            var valRes = await _movieService.ValidateMovieDtoAsync(newMovie);

            if (!valRes.isValid)
            {
                return BadRequest(valRes.errorMessage);
            }

            try
            {
                await _movieService.AddMovie(newMovie);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Помилка сервера", details = ex.Message });
            }

            return Ok($"Фільм додано");

            //_movieService.AddMovie(newMovie);
            //return CreatedAtAction(nameof(Get), new { id = newMovie.id }, newMovie);
        }

        // Обновить фильм
       /* [HttpPut("{id}")]
        public IActionResult Update(int id, Movie movie)
        {
            if (id != movie.Id) return BadRequest();
            _movieService.UpdateMovie(movie);
            return NoContent();
        }*/

        /*
        // Удалить фильм
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _movieService.DeleteMovie(id);
            return NoContent();
        }
        */
    }
}
