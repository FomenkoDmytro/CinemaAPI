using EpicVision.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicVision.Infrastructure_DAL.Repositories
{
    public interface ILanguageRepository
    {
        Task<IEnumerable<Language>> GetAllLanguagesDirectory();
        Task<IEnumerable<Language>> GetAllLanguagesWithMovies();
        Task<Language> GetById(int id);
        Task<bool> IsExistById(int id);
        Task Add(Language Language);
        Task Update(Language Language);
        Task Delete(int id);
    }
}
