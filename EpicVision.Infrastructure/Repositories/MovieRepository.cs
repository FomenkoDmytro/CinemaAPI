using EpicVision.Domain.Entities;
using EpicVision.Infrastructure_DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace EpicVision.Infrastructure_DAL.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAll() => _context.Movies.ToList();

        public async Task<IEnumerable<Movie>> GetMoviesFromDateTime(DateOnly startSessionDate, TimeOnly startSessionTime)
        {
            
            var movies = await _context.Movies.
                Include(x => x.Sessions)
                    .Where(x => x.Sessions.Any(s => (s.Date ==  startSessionDate && s.Time >= startSessionTime) || s.Date > startSessionDate))
                .ToListAsync();
            return movies;
        }

        public Movie GetById(int id) => _context.Movies.Find(id);

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void Update(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }

    
    }
}
