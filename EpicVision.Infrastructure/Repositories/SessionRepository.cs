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
    public class SessionRepository: ISessionRepository
    {
        private readonly ApplicationDbContext _context;

        public SessionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Session>> GetAllSessions()
        {
            return await _context.Sessions.ToListAsync();
        }

        public async Task<IEnumerable<Session>> GetByIds(IEnumerable<int> ids)
        {
            return await _context.Sessions
                .Where(s => ids.Contains(s.Id))
                .ToListAsync();
        }

        public async Task<List<int>> GetInvalidIds(IEnumerable<int> ids)
        {
            var existingIds = await _context.Sessions
                .Where(s => ids.Contains(s.Id))
                .Select(s => s.Id)
                .ToListAsync();

            return ids.Except(existingIds).ToList();
        }
    }
}
