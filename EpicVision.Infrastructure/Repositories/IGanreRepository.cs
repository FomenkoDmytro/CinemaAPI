using EpicVision.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicVision.Infrastructure_DAL.Repositories
{
    public interface IGanreRepository
    {
        Task<IEnumerable<Ganre>> GetAllGanresDictionary();
        Task<IEnumerable<Ganre>> GetAllGanresWithMovies();
        Task<Ganre> GetById(int id);
        Task<IEnumerable<Ganre>> GetByIds(IEnumerable<int> ids);
        Task<List<int>> GetInvalidIds(IEnumerable<int> ids);
        Task Add(Ganre ganre);
        Task Update(Ganre ganre);
        Task Delete(int id);
    }
}
