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
            _context.Add(ganre);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ganre>> GetAllGanres()
        {
            return await _context.Ganres.ToListAsync();
        }

        public void Update(Ganre ganre)
        {
            throw new NotImplementedException();
        }
    }
}
