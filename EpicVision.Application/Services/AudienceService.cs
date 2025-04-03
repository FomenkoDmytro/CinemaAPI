using EpicVision.Application_BLL.DTO.Audiences;
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
    public class AudienceService : IAudienceService
    {
        private readonly IAudienceRepository _audienceRepository;

        public AudienceService(IAudienceRepository audienceRepository)
        {
            _audienceRepository = audienceRepository;
        }

        public async Task Add(AddAudienceDto audienceDto)
        {
            var audience = new Audience { Category = audienceDto.Category};
            await _audienceRepository.Add(audience);
        }

        public async Task Delete(int id)
        {
            await _audienceRepository.Delete(id);
        }

        public async Task<IEnumerable<GetAllAudiencesDictionaryDto>> GetAllAudiencesDictionary()
        {
            var audiences = await _audienceRepository.GetAllAudiencesDirectory();
            return audiences
                .Select(a => new GetAllAudiencesDictionaryDto
                {
                    Id = a.Id,
                    Category = a.Category,
                }).ToList();

        }

        public async Task<IEnumerable<GetAllAudiencesWithMoviesDto>> GetAllAudiencesWithMovies()
        {
            var audiences = await _audienceRepository.GetAllAudiencesWithMovies();
            return audiences
                .Select(a => new GetAllAudiencesWithMoviesDto
                {
                    Id = a.Id,
                    Category = a.Category,
                    Movies = a.Movies.Select(m => new MovieShortDto
                    {
                        Id = m.Id,
                        Title = m.Title,
                    }).ToList()
                }).ToList();

        }

        public async Task Update(int id, UpdateAudienceDto audience)
        {
           var audienceForUpdate = await _audienceRepository.GetById(id);

            if(audienceForUpdate == null)
            {
                throw new KeyNotFoundException($"Аудиторія з id {id} не знайдено.");
            }

            audienceForUpdate.Category = audience.Category;

            await _audienceRepository.Update(audienceForUpdate);
        }
    }
}
