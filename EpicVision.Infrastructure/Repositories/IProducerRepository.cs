using EpicVision.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicVision.Infrastructure_DAL.Repositories
{
    public interface IProducerRepository
    {
        Task<IEnumerable<Producer>> GetAllProducersDirectory();
        Task<IEnumerable<Producer>> GetAllProducersWithMovies();
        Task<Producer> GetById(int id);
        Task<bool> IsExistById(int id);
        Task Add(Producer producer);
        Task Update(Producer producer);
        Task Delete(int id);
    }
}
