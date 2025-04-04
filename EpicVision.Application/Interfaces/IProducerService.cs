using EpicVision.Application_BLL.DTO.Producers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicVision.Application_BLL.Interfaces
{
    public interface IProducerService
    {
        Task<IEnumerable<GetAllProducersDictionaryDto>> GetAllProducersDictionary();
        Task<IEnumerable<GetAllProducersWithMoviesDto>> GetAllProducersWithMovies();

        Task Add(AddProducerDto producerDto);
        Task Update(int id, UpdateProducerDto producer);
        Task Delete(int id);
    }
}
