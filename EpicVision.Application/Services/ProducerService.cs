using EpicVision.Application_BLL.DTO.Producers;
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
    public class ProducerService: IProducerService
    {
        private readonly IProducerRepository _producerRepository;

        public ProducerService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public async Task Add(AddProducerDto producerDto)
        {
            var producer = new Producer
            {
                FirstName = producerDto.FirstName,
                LastName = producerDto.LastName
            };
            await _producerRepository.Add(producer);
        }

        public async Task Delete(int id)
        {
            await _producerRepository.Delete(id);
        }

        public async Task<IEnumerable<GetAllProducersDictionaryDto>> GetAllProducersDictionary()
        {
            var producers = await _producerRepository.GetAllProducersDirectory();
            return producers
                .Select(p => new GetAllProducersDictionaryDto
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                }).ToList();

        }

        public async Task<IEnumerable<GetAllProducersWithMoviesDto>> GetAllProducersWithMovies()
        {
            var producers = await _producerRepository.GetAllProducersWithMovies();
            return producers
                .Select(p => new GetAllProducersWithMoviesDto
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Movies = p.Movies.Select(m => new MovieShortDto
                    {
                        Id = m.Id,
                        Title = m.Title,
                    }).ToList()
                }).ToList();

        }

        public async Task Update(int id, UpdateProducerDto producer)
        {
            var producerForUpdate = await _producerRepository.GetById(id);

            if (producerForUpdate == null)
            {
                throw new KeyNotFoundException($"Продюсера з id {id} не знайдено.");
            }

            producerForUpdate.FirstName = producer.FirstName;
            producerForUpdate.LastName = producer.LastName;

            await _producerRepository.Update(producerForUpdate);
        }
    }
}
