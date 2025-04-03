using EpicVision.Application_BLL.DTO.Languages;
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
    public class LanguageService: ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task Add(AddLanguageDto languageDto)
        {
            var language = new Language { LanguageName = languageDto.LanguageName};
            await _languageRepository.Add(language);
        }

        public async Task Delete(int id)
        {
            await _languageRepository.Delete(id);
        }

        public async Task<IEnumerable<GetAllLanguagesDictionaryDto>> GetAllLanguagesDictionary()
        {
            var languages = await _languageRepository.GetAllLanguagesDirectory();
            return languages
                .Select(l => new GetAllLanguagesDictionaryDto
                {
                    Id = l.Id,
                    LanguageName = l.LanguageName,
                }).ToList();

        }

        public async Task<IEnumerable<GetAllLanguagesWithMoviesDto>> GetAllLanguagesWithMovies()
        {
            var languages = await _languageRepository.GetAllLanguagesWithMovies();
            return languages
                .Select(l => new GetAllLanguagesWithMoviesDto
                {
                    Id = l.Id,
                    LanguageName = l.LanguageName,
                    Movies = l.Movies.Select(m => new MovieShortDto
                    {
                        Id = m.Id,
                        Title = m.Title,
                    }).ToList()
                }).ToList();

        }

        public async Task Update(int id, UpdateLanguageDto language)
        {
            var languageForUpdate = await _languageRepository.GetById(id);

            if (languageForUpdate == null)
            {
                throw new KeyNotFoundException($"Мову з id {id} не знайдено.");
            }

            languageForUpdate.LanguageName = language.LanguageName;

            await _languageRepository.Update(languageForUpdate);
        }
    }
}
