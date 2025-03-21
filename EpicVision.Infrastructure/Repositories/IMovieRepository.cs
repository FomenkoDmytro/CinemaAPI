using EpicVision.Domain.Entities;

namespace EpicVision.Infrastructure_DAL.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();

        Task<IEnumerable<Movie>> GetMoviesFromDateTime(DateOnly startSessionDate, TimeOnly startSessionTime);
        Movie GetById(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
    }
}
