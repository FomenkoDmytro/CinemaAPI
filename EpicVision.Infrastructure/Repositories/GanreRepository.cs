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
    public class GanreRepository : IGanreRepository
    {
        private readonly ApplicationDbContext _context;

        public GanreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Ganre ganre)
        {
            await _context.AddAsync(ganre);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var ganre = await _context.Ganres.FindAsync(id);

            if (ganre != null)
            {
                _context.Remove(ganre);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Ganre>> GetAllGanresWithMovies()
        {
            return await _context.Ganres
                .Include(g => g.Movies)
                .ToListAsync();
        }



        public async Task<IEnumerable<Ganre>> GetAllGanresDictionary()
        {
            return await _context.Ganres.ToListAsync();
        }

        public async Task<Ganre> GetById(int id)
        {
            var ganre = await _context.Ganres.FindAsync(id);

            if(ganre == null)
            {
                throw new KeyNotFoundException($"Жанр з id {id} не знайдено.");
            }

            return ganre;
        }

        public async Task Update(Ganre ganre)
        {
           var ganreForUpdate = await _context.Ganres.FindAsync(ganre.Id);

            if (ganreForUpdate == null)
            {
                throw new KeyNotFoundException($"Жанр з id {ganre.Id} не знайдено.");
            }

            ganreForUpdate.Name = ganre.Name;

            await _context.SaveChangesAsync();
        }
    }
}
