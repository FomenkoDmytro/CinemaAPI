using EpicVision.Application_BLL.DTO;
using EpicVision.Application_BLL.Interfaces;
using EpicVision.Domain.Entities;
using EpicVision.Infrastructure_DAL.Repositories;

namespace EpicVision.Application_BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IEnumerable<Movie> GetAllMovies() => _movieRepository.GetAll();

        public async Task<IEnumerable<MoviesFromDateTime>> GetMoviesFromDate(DateOnly startSessionDate, TimeOnly startSessionTime)
        {
            var movies = await _movieRepository.GetMoviesFromDateTime(startSessionDate, startSessionTime);
                    return movies.
                        Select(m => new MoviesFromDateTime
                        {
                            Id = m.Id,
                            Title = m.Title,
                            ImageUrl = m.ImageUrl,
                            StartDate = m.StartDate,
                            Duration = m.Duration,
                            DurationUnit = m.DurationUnit,
                            Plot = m.Plot,
                            Audience = m.Audience.Category,
                            Producer = $"{m.Producer.FirstName} {m.Producer.LastName}",
                            Actors = m.Actors.ToList(),
                            Ganres = m.Ganres.ToList(),
                            Languages = m.Languages.ToList(),
                            Sessions = m.Sessions
                                .Where(s => (s.Date == startSessionDate && s.Time >= startSessionTime) || s.Date > startSessionDate).ToList(),
                        }).ToList();
        }

        public Movie GetMovieById(int id) => _movieRepository.GetById(id);
        public void AddMovie(Movie movie) => _movieRepository.Add(movie);
        public void UpdateMovie(Movie movie) => _movieRepository.Update(movie);
        public void DeleteMovie(int id) => _movieRepository.Delete(id);
    }
}
