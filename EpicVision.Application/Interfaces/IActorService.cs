using EpicVision.Application_BLL.DTO.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicVision.Application_BLL.Interfaces
{
    public interface IActorService
    {
        Task<IEnumerable<GetAllActorsDictionaryDto>> GetAllActorsDictionary();
        Task<IEnumerable<GetAllActorsWithMoviesDto>> GetAllActorsWithMovies();
        Task Add(AddActorDto actorDto);
        Task Update(int id, UpdateActorDto actor);
        Task Delete(int id);
    }
}
