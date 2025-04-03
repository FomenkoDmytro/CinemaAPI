using EpicVision.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpicVision.Application_BLL.DTO.Languages;


namespace EpicVision.Application_BLL.Interfaces
{
    public interface ILanguageService
    {
        Task<IEnumerable<GetAllLanguagesDictionaryDto>> GetAllLanguagesDictionary();
        Task<IEnumerable<GetAllLanguagesWithMoviesDto>> GetAllLanguagesWithMovies();

        Task Add(AddLanguageDto languageDto);
        Task Update(int id, UpdateLanguageDto language);
        Task Delete(int id);
    }
}
