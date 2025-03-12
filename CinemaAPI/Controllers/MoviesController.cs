using EpicVision.Application.Interfaces;
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
        public IActionResult GetAll() => Ok(_movieService.GetAllMovies());

        // Получить фильм по ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = _movieService.GetMovieById(id);
            return movie != null ? Ok(movie) : NotFound();
        }

        // Создать новый фильм
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            _movieService.AddMovie(movie);
            return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
        }

        // Обновить фильм
        [HttpPut("{id}")]
        public IActionResult Update(int id, Movie movie)
        {
            if (id != movie.Id) return BadRequest();
            _movieService.UpdateMovie(movie);
            return NoContent();
        }

        // Удалить фильм
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _movieService.DeleteMovie(id);
            return NoContent();
        }
    }
}
