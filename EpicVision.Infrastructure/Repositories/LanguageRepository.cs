using EpicVision.Domain.Entities;
using EpicVision.Infrastructure_DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicVision.Infrastructure_DAL.Repositories
{
    public class LanguageRepository : ILanguageRepository

    {
        private readonly ApplicationDbContext _context;

        public LanguageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Language language)
        {
            await _context.AddAsync(language);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var language = await _context.Languages.FindAsync(id);

            if (language != null)
            {
                _context.Languages.Remove(language);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Language>> GetAllLanguagesDirectory()
        {
            return await _context.Languages.ToListAsync();
        }

        public async Task<IEnumerable<Language>> GetAllLanguagesWithMovies()
        {
            return await _context.Languages.Include(a => a.Movies).ToListAsync();
        }


        public async Task<Language> GetById(int id)
        {
            var language = await _context.Languages.FindAsync(id);

            if(language == null)
            {
                throw new KeyNotFoundException($"Мову з id {id} не знайдено.");
            }

            return language;
        }

        public async Task Update(Language language)
        {
           var languageForUpdate = await _context.Languages.FindAsync(language.Id);

            if (languageForUpdate == null)
            {
                throw new KeyNotFoundException($"Мову з id {language.Id} не знайдено.");
            }

            languageForUpdate.LanguageName = language.LanguageName;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExistById(int id)
        {
            return await _context.Languages.AnyAsync(d => d.Id == id);
        }
    }
}
