using EpicVision.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpicVision.Application_BLL.DTO.Audiences;


namespace EpicVision.Application_BLL.Interfaces
{
    public interface IAudienceService
    {
        Task<IEnumerable<GetAllAudiencesDictionaryDto>> GetAllAudiencesDictionary();
        Task<IEnumerable<GetAllAudiencesWithMoviesDto>> GetAllAudiencesWithMovies();

        Task Add(AddAudienceDto audienceDto);
        Task Update(int id, UpdateAudienceDto audience);
        Task Delete(int id);
    }
}
