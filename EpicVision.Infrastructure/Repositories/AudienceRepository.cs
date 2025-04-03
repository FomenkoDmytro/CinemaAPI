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
    public class AudienceRepository : IAudienceRepository

    {
        private readonly ApplicationDbContext _context;

        public AudienceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Audience audience)
        {
            await _context.AddAsync(audience);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var audience = await _context.Audiences.FindAsync(id);

            if (audience != null)
            {
                _context.Remove(audience);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Audience>> GetAllAudiencesDirectory()
        {
            return await _context.Audiences.ToListAsync();
        }

        public async Task<IEnumerable<Audience>> GetAllAudiencesWithMovies()
        {
            return await _context.Audiences.Include(a => a.Movies).ToListAsync();
        }


        public async Task<Audience> GetById(int id)
        {
            var audience = await _context.Audiences.FindAsync(id);

            if(audience == null)
            {
                throw new KeyNotFoundException($"Аудиторію з id {id} не знайдено.");
            }

            return audience;
        }

        public async Task Update(Audience audience)
        {
           var audienceForUpdate = await _context.Audiences.FindAsync(audience.Id);

            if (audienceForUpdate == null)
            {
                throw new KeyNotFoundException($"Аудиторія з id {audience.Id} не знайдено.");
            }

            audienceForUpdate.Category = audience.Category;

            await _context.SaveChangesAsync();
        }
    }
}
