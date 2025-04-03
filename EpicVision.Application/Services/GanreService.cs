using EpicVision.Application_BLL.DTO.Ganres;
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
    public class GanreService : IGanreService
    {
        private readonly IGanreRepository _ganreRepository;

        public GanreService(IGanreRepository ganreRepository)
        {
            _ganreRepository = ganreRepository;
        }

        public async Task Add(AddGanreDto ganreDto)
        {
            var ganre = new Ganre { Name = ganreDto.Name };
            await _ganreRepository.Add(ganre);
        }

        public async Task Delete(int id)
        {
            await _ganreRepository.Delete(id);
        }

        public async Task<IEnumerable<GetAllGanresDictionaryDto>> GetAllGanresDictionary()
        {
            var ganres = await _ganreRepository.GetAllGanresDictionary();
            return ganres
                .Select(g => new GetAllGanresDictionaryDto
                {
                    Id = g.Id,
                    Name = g.Name,
                }).ToList();

        }

        public async Task<IEnumerable<GetAllGanresWithMoviesDto>> GetAllGanresWithMovies()
        {
            var ganres = await _ganreRepository.GetAllGanresWithMovies();
            return ganres
                .Select(g => new GetAllGanresWithMoviesDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    Movies = g.Movies.Select(m => new MovieShortDto
                    {
                        Id = m.Id,
                        Title = m.Title,
                    }).ToList()
                }).ToList();

        }

        public async Task Update(int id, UpdateGanreDto ganre)
        {
           var ganreForUpdate = await _ganreRepository.GetById(id);

            if(ganreForUpdate == null)
            {
                throw new KeyNotFoundException($"Жанр з id {id} не знайдено.");
            }

            ganreForUpdate.Name = ganre.Name;

            await _ganreRepository.Update(ganreForUpdate);
        }
    }
}
