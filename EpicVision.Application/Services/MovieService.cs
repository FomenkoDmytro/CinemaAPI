using EpicVision.Application.Interfaces;
using EpicVision.Domain.Entities;
using EpicVision.Infrastructure.Repositories;

namespace EpicVision.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IEnumerable<Movie> GetAllMovies() => _movieRepository.GetAll();
        public Movie GetMovieById(int id) => _movieRepository.GetById(id);
        public void AddMovie(Movie movie) => _movieRepository.Add(movie);
        public void UpdateMovie(Movie movie) => _movieRepository.Update(movie);
        public void DeleteMovie(int id) => _movieRepository.Delete(id);
    }
}
