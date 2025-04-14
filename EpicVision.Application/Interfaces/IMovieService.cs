using EpicVision.Application_BLL.DTO.Movies;
using EpicVision.Domain.Entities;

namespace EpicVision.Application_BLL.Interfaces
{
    public interface IMovieService
    {
        Task<(bool isValid, string errorMessage)> ValidateMovieDtoAsync(AddMovieDto dto);
        //IEnumerable<GetAllMoviesDto> GetAllMovies();
        Task<IEnumerable<MoviesFromDateTime>> GetMoviesFromDate(DateOnly startSessionDate, TimeOnly startSessionTime);
        //GetMovieByIdDto GetMovieById(int id);
        Task AddMovie(AddMovieDto movie);
        //void UpdateMovie(UpdateMovieDto movie);
        //void DeleteMovie(int id);
    }
}
