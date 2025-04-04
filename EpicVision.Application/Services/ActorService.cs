using EpicVision.Application_BLL.DTO.Actors;
using EpicVision.Application_BLL.Interfaces;
using EpicVision.Domain.Entities;
using EpicVision.Infrastructure_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicVision.Application_BLL.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task Add(AddActorDto actorDto)
        {
            var actor = new Actor
            {
                FirstName = actorDto.FirstName,
                LastName = actorDto.LastName
            };
            await _actorRepository.Add(actor);
        }

        public async Task Delete(int id)
        {
            await _actorRepository.Delete(id);
        }

        public async Task<IEnumerable<GetAllActorsDictionaryDto>> GetAllActorsDictionary()
        {
            var actors = await _actorRepository.GetAllActorsDirectory();
            return actors
                .Select(a => new GetAllActorsDictionaryDto
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                }).ToList();

        }

        public async Task<IEnumerable<GetAllActorsWithMoviesDto>> GetAllActorsWithMovies()
        {
            var actors = await _actorRepository.GetAllActorsWithMovies();
            return actors
                .Select(a => new GetAllActorsWithMoviesDto
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Movies = a.Movies.Select(m => new MovieShortDto
                    {
                        Id = m.Id,
                        Title = m.Title,
                    }).ToList()
                }).ToList();

        }

        public async Task Update(int id, UpdateActorDto actor)
        {
            var actorForUpdate = await _actorRepository.GetById(id);

            if (actorForUpdate == null)
            {
                throw new KeyNotFoundException($"Актора з id {id} не знайдено.");
            }

            actorForUpdate.FirstName = actor.FirstName;
            actorForUpdate.LastName = actor.LastName;

            await _actorRepository.Update(actorForUpdate);
        }
    }
}
