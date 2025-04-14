using EpicVision.Application_BLL.DTO.Movies;
using EpicVision.Application_BLL.Interfaces;
using EpicVision.Domain.Entities;
using EpicVision.Infrastructure_DAL.Repositories;

namespace EpicVision.Application_BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IDurationUnitRepository _durationUnitRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IAudienceRepository _audienceRepository;
        private readonly IProducerRepository _producerRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IGanreRepository _ganreRepository;
        private readonly ISessionRepository _sessionRepository;

        public MovieService(IMovieRepository movieRepository, IDurationUnitRepository durationUnitRepository,
            ILanguageRepository languageRepository, IAudienceRepository audienceRepository, IProducerRepository producerRepository,
            IActorRepository actorRepository, IGanreRepository ganreRepository, ISessionRepository sessionRepository)
        {
            _movieRepository = movieRepository;
            _durationUnitRepository = durationUnitRepository;
            _languageRepository = languageRepository;
            _audienceRepository = audienceRepository;
            _producerRepository = producerRepository;
            _actorRepository = actorRepository;
            _ganreRepository = ganreRepository;
            _sessionRepository = sessionRepository;
        }

        public async Task<(bool isValid, string errorMessage)> ValidateMovieDtoAsync(AddMovieDto dto)
        {
            if (dto == null)
            {
                return (false, "Об'єкт з фільмом пустий");
            }

            if (string.IsNullOrWhiteSpace(dto.Title))
            {
                return (false, "Відсутня назва фільму");
            }

            if (string.IsNullOrWhiteSpace(dto.ImageUrl))
            {
                return (false, "Відсутнє посилання на картинку фільма");
            }

            if (string.IsNullOrWhiteSpace(dto.Title))
            {
                return ((false, "Відсутнє посилання на трейлер фільма"));
            }

            if (string.IsNullOrWhiteSpace(dto.Title))
            {
                return ((false, "Відсутнє посилання на трейлер фільма"));
            }

            if (!DateOnly.TryParse(dto.StartDate, out _))
            {
                return (false, "Невірний формат дати старту показу фільму");
            }

            if (dto.Duration <= 0)
            {
                return (false, "Тривалість фільму повинна бути більше 0");
            }

            if (!await _durationUnitRepository.IsExistById(dto.DurationUnitId))
            {
                return (false, "Невірно вказана одиниця виміру часу");
            }

            if (!await _audienceRepository.IsExistById(dto.AudienceId))
            {
                return (false, "Невірно вказана категорія аудиторії");
            }

            if (!await _producerRepository.IsExistById(dto.ProducerId))
            {
                return (false, "Невірно вказаний продюсер");
            }

            if (!await _languageRepository.IsExistById(dto.LanguageId))
            {
                return (false, "Невірно вказана мова");
            }

            var actorIds = dto.Actors.Select(a => a.Id).ToList();
            var invalidActorIds = await _actorRepository.GetInvalidIds(actorIds);

            if (invalidActorIds.Any())
            {
                return (false, $"Вказані невірні актори: {string.Join(",", invalidActorIds)}");
            }

            var ganreIds = dto.Ganres.Select(g => g.Id).ToList();
            var invalidGanreIds = await _ganreRepository.GetInvalidIds(ganreIds);

            if (invalidGanreIds.Any())
            {
                return (false, $"Вказані невірні жанри: {string.Join(",", invalidGanreIds)}");
            }


            if (dto.Sessions != null && dto.Sessions.Any())
            {
                var sessionIds = dto.Sessions.Select(s => s.Id).ToList();
                var invalidSessionIds = await _sessionRepository.GetInvalidIds(sessionIds);

                if (invalidSessionIds.Any())
                {
                    return (false, $"Вказані невірні сессії: {string.Join(",", invalidSessionIds)}");
                }
            }

            return (true, null);
        }
        public async Task AddMovie(AddMovieDto movieDto)
        {
            var actorIds = movieDto.Actors.Select(a => a.Id).ToList();
            var actors = await _actorRepository.GetByIds(actorIds);

            var ganreIds = movieDto.Ganres.Select(g => g.Id).ToList();
            var ganres = await _ganreRepository.GetByIds(ganreIds);

            List<Session> sessions = new List<Session>();

            if (movieDto.Sessions != null && movieDto.Sessions.Any())
            {
                var sessionIds = movieDto.Sessions.Select(s => s.Id).ToList();
                sessions = (await _sessionRepository.GetByIds(sessionIds)).ToList();
            }


            var movie = new Movie
            {
                Title = movieDto.Title,
                ImageUrl = movieDto.ImageUrl,
                TrailerUrl = movieDto.TrailerUrl,
                StartDate = DateOnly.Parse(movieDto.StartDate),
                Duration = movieDto.Duration,
                DurationUnitId = movieDto.DurationUnitId,
                Plot = movieDto.Plot,
                AudienceId = movieDto.AudienceId,
                ProducerId = movieDto.ProducerId,
                LanguageId = movieDto.LanguageId,
                Actors = actors.ToList(),
                Ganres = ganres.ToList(),
                Sessions = sessions,
            };

            await _movieRepository.Add(movie);
        }

        //public IEnumerable<Movie> GetAllMovies() => _movieRepository.GetAll();

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
                    Language = m.Language.LanguageName,
                    Sessions = m.Sessions
                        .Where(s => (s.Date == startSessionDate && s.Time >= startSessionTime) || s.Date > startSessionDate).ToList(),
                }).ToList();
        }

        //public Movie GetMovieById(int id) => _movieRepository.GetById(id);
        //public void UpdateMovie(Movie movie) => _movieRepository.Update(movie);
        //public void DeleteMovie(int id) => _movieRepository.Delete(id);
    }
}
