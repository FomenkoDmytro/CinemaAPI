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

        public async Task<IEnumerable<Ganre>> GetAllGanres()
        {
            return await _context.Ganres.ToListAsync();
        }

        public Task Update(Ganre ganre)
        {
            throw new NotImplementedException();
        }
    }
}
