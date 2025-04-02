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

        async Task<IEnumerable<GetAllGanresDto>> IGanreService.GetAllGanres()
        {
            var ganres = await _ganreRepository.GetAllGanres();
            return ganres
                .Select(g => new GetAllGanresDto
                {
                    Id = g.Id,
                    Name = g.Name,
                }).ToList();

        }

        public Task Update(Ganre ganre)
        {
            throw new NotImplementedException();
        }
    }
}
