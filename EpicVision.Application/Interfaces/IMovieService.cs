using EpicVision.Application_BLL.DTO;
using EpicVision.Domain.Entities;

namespace EpicVision.Application_BLL.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAllMovies();
        Task<IEnumerable<MoviesFromDateTime>> GetMoviesFromDate(DateOnly startSessionDate, TimeOnly startSessionTime);
        Movie GetMovieById(int id);
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id);
    }
}
