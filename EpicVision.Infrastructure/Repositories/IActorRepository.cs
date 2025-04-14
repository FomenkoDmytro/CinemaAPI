using EpicVision.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicVision.Infrastructure_DAL.Repositories
{
    public interface IActorRepository
    {
        Task<IEnumerable<Actor>> GetAllActorsDirectory();
        Task<IEnumerable<Actor>> GetAllActorsWithMovies();
        Task<Actor> GetById(int id);
        Task<IEnumerable<Actor>> GetByIds(IEnumerable<int> ids);
        Task<List<int>> GetInvalidIds(IEnumerable<int> ids);
        Task Add(Actor actor);
        Task Update(Actor actor);
        Task Delete(int id);
    }
}
