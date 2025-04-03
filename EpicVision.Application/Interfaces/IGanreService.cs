using EpicVision.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpicVision.Application_BLL.DTO.Ganres;


namespace EpicVision.Application_BLL.Interfaces
{
    public interface IGanreService
    {
        Task<IEnumerable<GetAllGanresDictionaryDto>> GetAllGanresDictionary();
        Task<IEnumerable<GetAllGanresWithMoviesDto>> GetAllGanresWithMovies();

        Task Add(AddGanreDto ganreDto);
        Task Update(int id, UpdateGanreDto ganre);
        Task Delete(int id);
    }
}
